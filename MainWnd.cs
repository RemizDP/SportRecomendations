using Microsoft.Data.SqlClient;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Collections.Specialized.BitVector32;

namespace Приложение_консультант_по_подбору_спортивных_секций
{
    public partial class MainWnd : Form
    {
        private int childFormNumber = 0;
        public Auth? authWnd;
        public User? currUser;
        public Label? SemipersonalLabel;
        public MainWnd()
        {
            InitializeComponent();
        }

        public Panel[]? panels;
        public List<User> users = null;
        public List<SportSection> sections = null;
        public List<Rating> ratings = null;

        //загрузка данных из БД
        //______________________________________________________________________________________________________________________________
        public List<User> LoadUsers()
        {
            List<User> result = new List<User>();
            string queryString = $"select * from RegUser";
            SqlCommand command = new SqlCommand(queryString, authWnd.dataBase.GetConnection());
            authWnd.dataBase.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                User user = new User();
                authWnd.LoadUserData(reader, user);
                result.Add(user);
            }

            this.authWnd.dataBase.CloseConnection();
            return result;
        }
        public List<SportSection> LoadSections()
        {
            List<SportSection> result = new List<SportSection>();
            string queryString = $"select SportSection.section_id, Sport.sport_name, Sport.olympic_type, SportSection.section_name, SportSection.description, Sport.min_age, Sport.max_age, SportSection.lessons_per_week," +
                $"SportSection.cost, SportSection.section_location, SportSection.contacts" +
                $" from SportSection inner join Sport on SportSection.sport_id = Sport.sport_id";
            SqlCommand command = new SqlCommand(queryString, this.authWnd.dataBase.GetConnection());
            this.authWnd.dataBase.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SportSection section = new SportSection();
                section.id = reader.GetInt32(0);
                section.sport = reader.GetString(1);
                section.olympic_type = reader.GetString(2);
                section.name = reader.GetString(3);
                section.description = reader.GetString(4);
                section.minAge = reader.GetInt32(5);
                section.maxAge = reader.GetInt32(6);
                section.lessonsPerWeek = reader.GetInt32(7);
                section.cost = reader.GetInt32(8);
                section.location = reader.GetString(9);
                section.contacts = reader.GetString(10);

                result.Add(section);
            }
            authWnd.dataBase.CloseConnection();

            return result;
        }
        public List<Rating> LoadRatings(int recentDays)
        {
            List<Rating> result = new List<Rating>();
            string queryString = $"select rating_id, regUser_id, section_id, rating_weight, rating_date from Rating where DATEDIFF(day, rating_date, GETDATE())<{recentDays}";
            SqlCommand command = new SqlCommand(queryString, authWnd.dataBase.GetConnection());
            authWnd.dataBase.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Rating rating = new Rating();
                rating.id = reader.GetInt32(0);
                rating.user_id = reader.GetInt32(1);
                rating.section_id = reader.GetInt32(2);
                rating.weight = reader.GetInt32(3);
                rating.date = reader.GetDateTime(4);

                result.Add(rating);
            }
            authWnd.dataBase.CloseConnection();
            return result;
        }
        //______________________________________________________________________________________________________________________________

        //рекомендации
        //______________________________________________________________________________________________________________________________
        public int NonPersonalRecommendation(SportSection s)
        {
            string queryString2 = $"select cast(isnull(avg(rating_weight), 0) as float) from rating where (rating_type = 'оценка пользователем' AND section_id = {s.id})";
            SqlCommand command2 = new SqlCommand(queryString2, this.authWnd.dataBase.GetConnection());
            this.authWnd.dataBase.OpenConnection();
            SqlDataReader reader2 = command2.ExecuteReader();
            if (reader2.Read())
                if (reader2.GetDouble(0) < 0)
                    s.averageRating = 0;
                else
                    s.averageRating = reader2.GetDouble(0);
            authWnd.dataBase.CloseConnection();
            return Convert.ToInt32(s.averageRating);
        }
        //добавить схожесть пользователей по данным
        public void SemiPersonalRecommendation(SportSection s)
        {
            if (s.location == currUser.location)
                s.relevance += 2;
            if (s.minAge <= currUser.age && s.maxAge >= currUser.age)
                s.relevance += 2;
            else
                s.relevance -= 4;
            if (s.olympic_type == "Единоборства" && !currUser.sex)
                s.relevance++;
            if ((s.olympic_type == "Циклический" || s.sport == "Волейбол") && currUser.sex)
                s.relevance++;
            if (((currUser.sex == true && currUser.height > 172) || (currUser.sex == false && currUser.height > 182)) && (s.sport == "Волейбол" || s.sport == "Баскетбол"))
                s.relevance++;
        }
        public void SectionsRelevance()
        {
            if (sections != null)
            {
                foreach (SportSection s in sections)
                {
                    //загрузка флага желаемого
                    string queryString2 = $"select count(*) from Rating where (regUser_id = {currUser.id} AND section_id = {s.id} AND rating_type = 'желаемое')";
                    SqlCommand command2 = new SqlCommand(queryString2, this.authWnd.dataBase.GetConnection());
                    this.authWnd.dataBase.OpenConnection();
                    SqlDataReader reader2 = command2.ExecuteReader();
                    if (reader2.Read())
                        if (reader2.GetInt32(0) > 0)
                            s.wishlist = true;
                    authWnd.dataBase.CloseConnection();

                    //подсчет релевантности
                    s.relevance = 0;
                    //неперсональные рекомендации
                    s.relevance += NonPersonalRecommendation(s);
                    //полуперсональные рекомендации
                    SemiPersonalRecommendation(s);
                }
                string queryString = $"select Sport.sport_name from Achievement inner join Sport on Achievement.sport_id = Sport.sport_id where Achievement.regUser_id = {currUser.id}";
                SqlCommand command = new SqlCommand(queryString, authWnd.dataBase.GetConnection());
                authWnd.dataBase.OpenConnection();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foreach (SportSection s in sections)
                    {
                        if (s.sport == reader.GetString(0))
                            s.relevance++;
                    }
                }
                this.authWnd.dataBase.CloseConnection();


                sections = sections.OrderByDescending(s => s.relevance).ToList();
            }
        }

        public int[,] MatrixForJaccard()
        {
            int[,] UsersAndElementsMatrix = new int[users.Count + 1, sections.Count + 1];
            bool sectionsFlag = false;
            UsersAndElementsMatrix[0, 0] = 0;
            for (int i = 0; i < users.Count; i++)
            {
                UsersAndElementsMatrix[i + 1, 0] = users[i].id;
                for (int j = 0; j < sections.Count; j++)
                {
                    if (!sectionsFlag)
                        UsersAndElementsMatrix[0, j + 1] = sections[j].id;
                    if (ratings.Find(r => (r.user_id == users[i].id) && (r.section_id == sections[j].id) && (r.weight == 10)) != null)
                        UsersAndElementsMatrix[i + 1, j + 1] = 1;
                    else
                        UsersAndElementsMatrix[i + 1, j + 1] = 0;
                }
                sectionsFlag = true;
            }
            return UsersAndElementsMatrix;
        }
        //сходство контента
        public double JaccardSimilarity_Content(int section1_id, int section2_id, int[,] UsersAndElementsMatrix)
        {
            int s1_index = 0;
            int s2_index = 0;
            int sumBoth = 0;
            int sumUnion = 0;
            for (int j = 0; j < UsersAndElementsMatrix.GetLength(1) - 1; j++)
            {
                if (UsersAndElementsMatrix[0, j + 1] == section1_id)
                    s1_index = j + 1;
                else if (UsersAndElementsMatrix[0, j + 1] == section2_id)
                    s2_index = j + 1;
            }
            if (s1_index == 0 || s2_index == 0)
                return -1;
            for (int i = 0; i < UsersAndElementsMatrix.GetLength(0) - 1; i++)
            {
                if (UsersAndElementsMatrix[i + 1, s1_index] == 1 && UsersAndElementsMatrix[i + 1, s2_index] == 1)
                    sumBoth++;
                else if (UsersAndElementsMatrix[i + 1, s1_index] == 1 || UsersAndElementsMatrix[i + 1, s2_index] == 1)
                    sumUnion++;
            }
            if (sumUnion == 0)
                return 0;
            double result = (double)sumBoth / (double)sumUnion;
            return result * 2 - 1;
        }

        //сходство пользователей по оценкам секций
        public double L1NormSimilarity_User(List<SportSection> user1RatedSections, List<SportSection> user2RatedSections)
        {
            List<SportSection> sectionsList = new List<SportSection>();
            AddUniqueSections(ref sectionsList, user1RatedSections);
            AddUniqueSections(ref sectionsList, user2RatedSections);
            double sum = 0;
            int k = 0;
            foreach (SportSection section in sectionsList)
            {
                int k1 = GetSectionIndex(section.id, user1RatedSections);
                int k2 = GetSectionIndex(section.id, user2RatedSections);

                if (!(k1 < 0 || k2 < 0))
                {
                    double user1_rating = user1RatedSections.Find(s => FindSectionById(s, section.id)).normalizedRating;
                    double user2_rating = user2RatedSections.Find(s => FindSectionById(s, section.id)).normalizedRating;
                    double rating1;
                    double rating2;
                    if (user1_rating > user2_rating)
                    {
                        rating1 = 1;
                        rating2 = user2_rating / user1_rating;
                    }
                    else
                    {
                        rating1 = user1_rating / user2_rating;
                        rating2 = 1;
                    }
                    double norm = (((double)1 / (Math.Abs(rating1 - rating2) + 1)) * 2) - 1;
                    sum += norm;
                    k++;
                }
            }
            if (k == 0)
                return -1;
            return sum / k;
        }

        public List<Rating> MaxUserRating(int user_id)
        {
            List<Rating> userRatings = new List<Rating>();
            foreach (Rating r in ratings)
            {
                if (r.user_id == user_id)
                    userRatings.Add(r);
            }

            for (int i = 0; i < userRatings.Count; i++)
            {
                double rating = 0;
                int section_id = userRatings[i].section_id;
                rating += userRatings[i].Decay();
                for (int j = i + 1; j < userRatings.Count; j++)
                {
                    if (userRatings[j].section_id == section_id)
                    {
                        rating += userRatings[j].Decay();
                    }
                }

                int k = GetUserIndex(user_id);
                if (rating > users[k].maxRating)
                {
                    users[k].maxRating = rating;
                    if (user_id == currUser.id)
                    {
                        currUser.maxRating = rating;
                    }
                }
            }
            return userRatings;
        }
        public void NormalizedToScaleUserRating(int user_id, List<Rating> userRatings, ref List<SportSection> userRatedSections)
        {
            int k1 = GetUserIndex(user_id);
            MaxUserRating(users[k1].id);
            List<double[]> result = new List<double[]>();
            while (userRatings.Count > 0)
            {
                Rating r = userRatings[0];
                int section_id = r.section_id;
                int k2 = GetSectionIndex(section_id, sections);
                if (!userRatedSections.Contains(sections[k2]))
                    userRatedSections.Add(sections[k2]);
                double rating = r.Decay();
                userRatings.Remove(r);
                for (int j = 0; j < userRatings.Count; j++)
                {
                    if (userRatings[j].section_id == section_id)
                    {
                        rating += userRatings[j].Decay();
                        userRatings.Remove(userRatings[j]);
                    }
                }
                k2 = GetSectionIndex(section_id, userRatedSections);
                userRatedSections[k2].normalizedRating = (rating / users[k1].maxRating) * 10;
            }
        }
        //возвращает среднюю оценку пользователя для оцененных им элементов контента
        public double MeanUserRating(int user_id, List<SportSection> userRatedSections)
        {
            double sum = 0;
            foreach (SportSection s in userRatedSections)
            {
                sum += s.normalizedRating;
            }

            int k = GetUserIndex(user_id);
            users[k].meanRating = sum / userRatedSections.Count;
            if (user_id == currUser.id)
                currUser.meanRating = sum / userRatedSections.Count;
            return users[k].meanRating;
        }
        //подсчет нормализированных оценок для всех секций сразу (для аналитики)
        public List<double[]> NormalizedFromMeanUserRating(int user_id, List<SportSection> userRatedSections)
        {
            List<double[]> result = new List<double[]>();
            double meanRating = MeanUserRating(user_id, userRatedSections);
            foreach (SportSection s in userRatedSections)
            {
                double normalizedRating = 0;
                if (s.normalizedRating != 0)
                    normalizedRating = s.normalizedRating - meanRating;
                double[] SectionIdAndNormalisedRating = { s.id, normalizedRating };
                result.Add(SectionIdAndNormalisedRating);
            }
            return result;
        }
        //подсчет нормализированной оценки для одной секции
        public double NormalizedFromMeanUserRating(int user_id, SportSection section)
        {
            int k = GetUserIndex(user_id);
            double result = 0;
            if (section.normalizedRating != 0)
                result = section.normalizedRating - users[k].meanRating;
            return result;
        }
        // скорректированное сходство Отиаи для контента
        public double AdjustedLikenessOfOchiai_Content(List<User> usersList, SportSection section1, SportSection section2)
        {
            double sum1 = 0;
            double sum2 = 0;
            double sum3 = 0;
            foreach (User u in usersList)
            {
                sum1 += NormalizedFromMeanUserRating(u.id, section1) * NormalizedFromMeanUserRating(u.id, section2);
                sum2 += NormalizedFromMeanUserRating(u.id, section1) * NormalizedFromMeanUserRating(u.id, section1);
                sum3 += NormalizedFromMeanUserRating(u.id, section2) * NormalizedFromMeanUserRating(u.id, section2);
            }
            double result = -1;
            if (sum2 > 0 && sum3 > 0)
                result = sum1 / (Math.Sqrt(sum2) * Math.Sqrt(sum3));
            return result;
        }
        //возвращает матрицу сходства секций по критерию Отиаи  (для аналитики)
        public double[,] MatrixLikenessOfOchiai_Content(List<User> usersList)
        {
            double[,] result = new double[sections.Count, sections.Count];
            for (int i = 0; i < sections.Count; i++)
            {
                for (int j = 0; j < sections.Count; j++)
                {
                    if (i == j)
                        result[i, j] = 1;
                    else
                        result[i, j] = AdjustedLikenessOfOchiai_Content(usersList, sections[i], sections[j]);
                }
            }
            return result;
        }
        // схожесть пользователей по секциям, которые оценили оба
        public double PearsonCorrelation_User(int user1_id, int user2_id, List<SportSection> user1RatedSections, List<SportSection> user2RatedSections)
        {
            double sum1 = 0;
            double sum2 = 0;
            double sum3 = 0;
            List<SportSection> sections1 = user1RatedSections;
            List<SportSection> sections2 = user1RatedSections;

            if (user1RatedSections.Count > user2RatedSections.Count)
            {
                sections1 = user2RatedSections;
                sections2 = user1RatedSections;
            }
            for (int i = 0; i < sections1.Count; i++)
            {
                int j = GetSectionIndex(sections1[i].id, sections2);
                if (j > -1)
                {
                    sum1 += NormalizedFromMeanUserRating(user1_id, sections1[i]) * NormalizedFromMeanUserRating(user2_id, sections2[j]);
                    sum2 += NormalizedFromMeanUserRating(user1_id, sections1[i]) * NormalizedFromMeanUserRating(user1_id, sections1[i]);
                    sum3 += NormalizedFromMeanUserRating(user2_id, sections2[j]) * NormalizedFromMeanUserRating(user2_id, sections2[j]);
                }
            }
            double result = -1;
            if (sum2 > 0 && sum3 > 0)
                result = sum1 / (Math.Sqrt(sum2) * Math.Sqrt(sum3));
            return result;
        }
        // для аналитики
        public double[,] MatrixPearsonCorrelation_User(int minRatedSections)
        {
            double[,] result = new double[users.Count, users.Count];
            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j < users.Count; j++)
                {
                    if (i == j)
                        result[i, j] = 1;
                    else
                        result[i, j] = UsersSimilarity_Pearson(users[i].id, users[j].id, minRatedSections);
                }
            }
            return result;
        }
        public double[,] MatrixL1Norm_User(int minRatedSections)
        {
            double[,] result = new double[users.Count, users.Count];
            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j < users.Count; j++)
                {
                    if (i == j)
                        result[i, j] = 1;
                    else
                        result[i, j] = UsersSimilarity_L1Norm(users[i].id, users[j].id, minRatedSections);
                }
            }
            return result;
        }

        public int PrepareDataForRecommendations(int user_id, out List<Rating> userRatings, out List<SportSection> ratedSections, int minRatedSectionsCount)
        {
            int k = GetUserIndex(user_id);
            List<Rating> ratings1 = MaxUserRating(users[k].id);
            List<SportSection> sections1 = new List<SportSection>();
            NormalizedToScaleUserRating(users[k].id, ratings1, ref sections1);
            MeanUserRating(users[k].id, sections1);
            userRatings = ratings1;
            ratedSections = sections1;
            if (ratedSections.Count < minRatedSectionsCount)
                return -1;
            return k;
        }
        public double UsersSimilarity_L1Norm(int user1_id, int user2_id, int minRatedSections)
        {
            List<Rating> user1Ratings;
            List<Rating> user2Ratings;
            List<SportSection> ratedSections1;
            List<SportSection> ratedSections2;
            int k1 = PrepareDataForRecommendations(user1_id, out user1Ratings, out ratedSections1, minRatedSections);
            int k2 = PrepareDataForRecommendations(user2_id, out user2Ratings, out ratedSections2, minRatedSections);
            if (k1 < 0 || k2 < 0)
                return -1;
            return L1NormSimilarity_User(ratedSections1, ratedSections2);
        }
        public double UsersSimilarity_Pearson(int user1_id, int user2_id, int minRatedSections)
        {
            List<Rating> user1Ratings;
            List<Rating> user2Ratings;
            List<SportSection> ratedSections1;
            List<SportSection> ratedSections2;
            int k1 = PrepareDataForRecommendations(user1_id, out user1Ratings, out ratedSections1, minRatedSections);
            int k2 = PrepareDataForRecommendations(user2_id, out user2Ratings, out ratedSections2, minRatedSections);
            if (k1 < 0 || k2 < 0)
                return -1;
            return PearsonCorrelation_User(users[k1].id, users[k2].id, ratedSections1, ratedSections2);
        }
        //кластеризация пользователей
        public List<User> Clustering_User(int user_id, double thresholdValue, int similarUserMinCount, double step, int minRatedSectionsCount)
        {
            List<User> similarUsers = new List<User>();
            for (int i = 0; i < users.Count; i++)
            {
                if (L1NormButton.Checked)
                {
                    if ((UsersSimilarity_L1Norm(user_id, users[i].id, minRatedSectionsCount) > thresholdValue) && user_id != users[i].id)
                        similarUsers.Add(users[i]);
                }
                if (PearsonButton.Checked)
                {
                    if ((UsersSimilarity_Pearson(user_id, users[i].id, minRatedSectionsCount) > thresholdValue) && user_id != users[i].id)
                        similarUsers.Add(users[i]);
                }
            }
            while (similarUsers.Count < similarUserMinCount && thresholdValue > -1)
            {
                thresholdValue -= step;
                for (int i = 0; i < users.Count; i++)
                {

                    if ((UsersSimilarity_Pearson(user_id, users[i].id, minRatedSectionsCount) > thresholdValue) && user_id != users[i].id)
                    {
                        if (!similarUsers.Contains(users[i]))
                            similarUsers.Add(users[i]);
                    }

                }
            }
            return similarUsers;
        }
        public List<SportSection> ContentFilter_Ochiai(List<User> usersList, int section1_id, double thresholdValue, int similarSectionMinCount, double step, int minRatedSectionsCount)
        {
            List<SportSection> result = new List<SportSection>();
            foreach (User user in usersList)
            {
                List<Rating> user1Ratings;
                List<SportSection> ratedSections1;
                int k = PrepareDataForRecommendations(user.id, out user1Ratings, out ratedSections1, minRatedSectionsCount);
                if (k >= 0)
                {
                    int k1 = GetSectionIndex(section1_id, ratedSections1);
                    foreach (SportSection section2 in sections)
                    {
                        int k2 = GetSectionIndex(section2.id, ratedSections1);
                        if (k1 != -1 && k2 != -1)
                        {
                            if (AdjustedLikenessOfOchiai_Content(usersList, ratedSections1[k1], ratedSections1[k2]) > thresholdValue)
                            {
                                result.Add(section2);
                            }
                        }
                    }
                }
            }
            while (result.Count < similarSectionMinCount && thresholdValue > -1)
            {
                thresholdValue -= step;
                foreach (User user in usersList)
                {
                    List<Rating> user1Ratings;
                    List<SportSection> ratedSections1;
                    int k = PrepareDataForRecommendations(user.id, out user1Ratings, out ratedSections1, minRatedSectionsCount);
                    if (k >= 0)
                    {
                        int k1 = GetSectionIndex(section1_id, ratedSections1);
                        foreach (SportSection section2 in sections)
                        {
                            int k2 = GetSectionIndex(section2.id, ratedSections1);
                            if (k1 != -1 && k2 != -1)
                            {
                                if (AdjustedLikenessOfOchiai_Content(usersList, ratedSections1[k1], ratedSections1[k2]) > thresholdValue)
                                {
                                    result.Add(section2);
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }


        /*Не следует использовать совместную фильтра-
        цию на пользователях, которые оценили только один или два элемента.Если
        перекрывающихся пользователей слишком много, то также может оказаться
        трудно найти сходство, поскольку рекомендации получатся слишком общими.*/

        // (регрессия) требуется найти похожих пользователей и усреднить их оценки элемента
        public List<SportSection> Regression(int user_id, int section_id, double thresholdCluster, double thresholdContent, int userMinCount, int sectionMinCount, double clusterStep, double contentStep, int minRatedSectionsCount)
        {
            List<User> cluster = Clustering_User(user_id, thresholdCluster, userMinCount, clusterStep, minRatedSectionsCount);
            return ContentFilter_Ochiai(cluster, section_id, thresholdContent, sectionMinCount, contentStep, minRatedSectionsCount);
        }

        public int MakeRecommendations(int totalCount, int user_id, ref List<SportSection> sectionsList, ref List<Rating> userRatings, ref List<SportSection> userRatedSections, double thresholdCluster, double thresholdContent, int usersMinCount, int sectionsMinCount, double stepCluster, double stepContent, int ratedSectionsMinCount)
        {
            int currUserIndex = -1;
            for (int i = 0; currUserIndex < 0 && totalCount > 0; i++)
            {
                currUserIndex = PrepareDataForRecommendations(user_id, out userRatings, out userRatedSections, totalCount);
                if (currUserIndex < 0)
                    totalCount--;
            }
            if (currUserIndex < 0)
                return -1;
            userRatedSections = userRatedSections.OrderByDescending(s => s.normalizedRating).ToList();
            foreach (SportSection s in userRatedSections)
            {
                if (ContentFilterButton.Checked)
                    AddUniqueSections(ref sectionsList, ContentFilter_Ochiai(users, s.id, thresholdContent, sectionsMinCount, stepContent, ratedSectionsMinCount));
                if (RegressionButton.Checked)
                    AddUniqueSections(ref sectionsList, Regression(user_id, s.id, thresholdCluster, thresholdContent, usersMinCount, sectionsMinCount, stepCluster, stepContent, ratedSectionsMinCount));
            }
            return sectionsList.Count;
        }
        public (IDataView training, IDataView test) LoadMLData(MLContext mlContext)
        {
            var trainingDataPath = Path.Combine(Environment.CurrentDirectory, "ML Data", "train-data.csv");
            var testDataPath = Path.Combine(Environment.CurrentDirectory, "ML Data", "test-data.csv");

            IDataView trainingDataView = mlContext.Data.LoadFromTextFile<SectionRating>(trainingDataPath, hasHeader: true, separatorChar: ',');
            IDataView testDataView = mlContext.Data.LoadFromTextFile<SectionRating>(testDataPath, hasHeader: true, separatorChar: ',');

            return (trainingDataView, testDataView);
        }
        public ITransformer BuildAndTrainModel(MLContext mlContext, IDataView trainingDataView, int iterationsCount, int approximationRank)
        {
            IEstimator<ITransformer> estimator = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: "userId")
            .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "sectionIdEncoded", inputColumnName: "sectionId"));
            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "userIdEncoded",
                MatrixRowIndexColumnName = "sectionIdEncoded",
                LabelColumnName = "Label",
                NumberOfIterations = iterationsCount,
                ApproximationRank = approximationRank
            };

            var trainerEstimator = estimator.Append(mlContext.Recommendation().Trainers.MatrixFactorization(options));
            Console.WriteLine("=============== Training the model ===============");
            ITransformer model = trainerEstimator.Fit(trainingDataView);

            return model;
        }
        public void EvaluateModel(MLContext mlContext, IDataView testDataView, ITransformer model)
        {
            Console.WriteLine("=============== Evaluating the model ===============");
            var prediction = model.Transform(testDataView);
            var metrics = mlContext.Regression.Evaluate(prediction, labelColumnName: "Label", scoreColumnName: "Score");
            Console.WriteLine("Root Mean Squared Error : " + metrics.RootMeanSquaredError.ToString());
            Console.WriteLine("RSquared: " + metrics.RSquared.ToString());
        }
        public bool UseModelForSinglePrediction(MLContext mlContext, ITransformer model, int user_id, int section_id, double thresholdRating)
        {
            var predictionEngine = mlContext.Model.CreatePredictionEngine<SectionRating, SectionRatingPrediction>(model);
            var testInput = new SectionRating { userId = user_id, sectionId = section_id };

            var sectionRatingPrediction = predictionEngine.Predict(testInput);
            if (sectionRatingPrediction.Score > thresholdRating)
            {
                return true;
            }
            return false;
        }
        public void SaveModel(MLContext mlContext, DataViewSchema trainingDataViewSchema, ITransformer model)
        {
            var modelPath = Path.Combine(Environment.CurrentDirectory, "ML Data", "model.zip");
            mlContext.Model.Save(model, trainingDataViewSchema, modelPath);
        }
        public void TrainMLModel(int iterationsCount, int approximationRank)
        {
            MLContext mlContext = new MLContext();
            try
            {
                (IDataView trainingDataView, IDataView testDataView) = LoadMLData(mlContext);
                ITransformer model = BuildAndTrainModel(mlContext, trainingDataView, iterationsCount, approximationRank);
                EvaluateModel(mlContext, testDataView, model);
                SaveModel(mlContext, trainingDataView.Schema, model);
            }
            catch
            {
                return;
            }
        }
        public void UseML(int user_id, double threshold, List<SportSection> sections1, ref List<SportSection> sectionsList)
        {
            MLContext mlContext = new MLContext();
            DataViewSchema modelSchema;
            try
            {
                var modelPath = Path.Combine(Environment.CurrentDirectory, "ML Data", "model.zip");
                ITransformer model = mlContext.Model.Load(modelPath, out modelSchema);
                foreach (SportSection s in sections1)
                {
                    int k = GetSectionIndex(s.id, sections1);

                    if (UseModelForSinglePrediction(mlContext, model, user_id, s.id, threshold))
                    {
                        sectionsList.Add(s);
                    }
                }
            }
            catch
            {
                return;
            }
        }



        //______________________________________________________________________________________________________________________________


        //инструменты
        //______________________________________________________________________________________________________________________________
        public bool FindSectionById(SportSection section, int section_id)
        {
            return section_id == section.id;
        }
        public int GetSectionIndex(int section_id, List<SportSection> list)
        {
            return list.FindIndex(s => FindSectionById(s, section_id));
        }
        public bool FindUserById(User user, int user_id)
        {
            return user_id == user.id;
        }
        public int GetUserIndex(int user_id)
        {
            return users.FindIndex(u => FindUserById(u, user_id));
        }
        public int AddUniqueSections(ref List<SportSection> list1, List<SportSection> list2)
        {
            int k = 0;
            foreach (SportSection s in list2)
            {
                if (GetSectionIndex(s.id, list1) < 0)
                {
                    list1.Add(s);
                    k++;
                }
            }
            return k;
        }
        public string PrintArray(int[,] arr)
        {
            string result = "";
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    result += $" {arr[i, j]} ";
                }
                result += "\n";
            }
            return result;
        }
        //______________________________________________________________________________________________________________________________

        //Работа с окнами
        //______________________________________________________________________________________________________________________________
        public void DeletePanels()
        {
            if (panels != null)
                foreach (Panel p in panels)
                {
                    Controls.Remove(p);
                }
        }
        public void AddStarToLabel(Label label, int k)
        {
            var star = "\u2605";
            if (sections[k].wishlist)
                label.Text += star;
        }
        public FlowLayoutPanel CreatePanel(MainWnd mainWnd, int sectionIndex, int pos_x, int pos_y, int height, int width)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            mainWnd.Controls.Add(panel);
            panel.Location = new Point(pos_x, pos_y);
            panel.Height = height;
            panel.Width = width;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = Color.FromArgb(210, 245, 255);
            panel.MaximumSize = new Size(width, height);
            panel.MinimumSize = new Size(width, height);
            panel.Visible = true;
            panel.AutoScroll = true;

            //добавление элементов панели
            Label HeadingLabel = new Label();
            HeadingLabel.AutoSize = true;
            HeadingLabel.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            Label ShortInfoLabel = new Label();
            ShortInfoLabel.AutoSize = true;
            ShortInfoLabel.Font = new Font("Segoe UI", 9);

            Label CostPerMonthLabel = new Label();
            CostPerMonthLabel.AutoSize = true;
            CostPerMonthLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            System.Windows.Forms.TextBox DescriptionBox = new System.Windows.Forms.TextBox();
            DescriptionBox.Font = new Font("Segoe UI", 9);
            DescriptionBox.ReadOnly = true;
            DescriptionBox.ScrollBars = ScrollBars.Both;
            DescriptionBox.Size = new Size(width - 10, height - 110);
            DescriptionBox.MaximumSize = new Size(width - 10, height - 110);
            DescriptionBox.Multiline = true;

            LinkLabel DetailsLabel = new LinkLabel();
            DetailsLabel.Font = new Font("Segoe UI", 9);
            DetailsLabel.LinkClicked += new LinkLabelLinkClickedEventHandler((sender, e) => ShowDetails(sender, e, sectionIndex, pos_y));

            panel.Controls.Add(HeadingLabel);
            panel.Controls.Add(ShortInfoLabel);
            panel.Controls.Add(CostPerMonthLabel);
            panel.Controls.Add(DescriptionBox);
            panel.Controls.Add(DetailsLabel);

            //загрузка данных о секции в панель

            HeadingLabel.Text = sections[sectionIndex].name;
            AddStarToLabel(HeadingLabel, sectionIndex);
            ShortInfoLabel.Text = sections[sectionIndex].sport + ", " + sections[sectionIndex].minAge.ToString() + "-" + sections[sectionIndex].maxAge.ToString() + ", " + sections[sectionIndex].location;
            CostPerMonthLabel.Text = sections[sectionIndex].cost.ToString() + " р./месяц, " + sections[sectionIndex].lessonsPerWeek.ToString() + " занятий в неделю";
            DescriptionBox.Text = sections[sectionIndex].description.Substring(0, 300) + "...";
            DetailsLabel.Text = "Подробнее";
            return panel;
        }
        //генерация панелей с персональными рекомендациями 
        public FlowLayoutPanel[] PersonalPanels(int totalCount, int colCount, int x, int y, int xMargin, int yMargin, int height, int width, ref int pos_y)
        {
            double thresholdContent = 0.75;
            double thresholdCluster = 0.75;
            double stepContent = 0.1;
            double stepCluster = 0.1;
            int sectionsMinCount = 1;
            int usersMinCount = 1;
            int ratedSectionsMinCount = 2;

            double thresholdRating = 5;
            if (sections != null)
            {
                List<SportSection> sectionsList = new List<SportSection>();

                List<Rating> userRatings = new List<Rating>();
                List<SportSection> userRatedSections = new List<SportSection>();
                List<SportSection> recommendedSections = new List<SportSection>();
                //функция, вычисляющая персональные рекомендации функциями подобия
                if (MakeRecommendations(totalCount, currUser.id, ref recommendedSections, ref userRatings, ref userRatedSections, thresholdCluster, thresholdContent, usersMinCount, sectionsMinCount, stepCluster, stepContent, ratedSectionsMinCount) < 0)
                    return null;
                AddUniqueSections(ref sectionsList, recommendedSections);
                if (MLRecommendationsBox.Checked)
                {
                    List<SportSection> mlSections = new List<SportSection>();
                    UseML(currUser.id, thresholdRating, sections, ref mlSections);
                    AddUniqueSections(ref sectionsList, mlSections);
                }
                //если секций мало, то можно добавить из списка оцененных
                if (sectionsList.Count < totalCount)
                    AddUniqueSections(ref sectionsList, userRatedSections);
                if (sectionsList.Count>totalCount)
                    sectionsList = sectionsList.GetRange(0, totalCount);
                totalCount = sectionsList.Count;
                List<int> personalSectionsIndexes = new List<int>();
                for (int i = 0; i < sectionsList.Count; i++)
                {
                    personalSectionsIndexes.Add(GetSectionIndex(sectionsList[i].id, sections));
                }
                FlowLayoutPanel[] panels = new FlowLayoutPanel[totalCount];
                int rowCount;
                if (totalCount % colCount == 0)
                    rowCount = totalCount / colCount;
                else
                    rowCount = totalCount / colCount + 1;
                int pos_x;



                for (int i = 0; i < rowCount; i++)
                {
                    pos_y = y + (yMargin + height) * i;
                    for (int j = 0; j < colCount; j++)
                    {
                        int k = i * colCount + j;
                        if (k >= totalCount)
                            return panels;
                        pos_x = x + (xMargin + width) * j;
                        panels[k] = CreatePanel(this, personalSectionsIndexes[k], pos_x, pos_y, height, width);
                    }
                }
                pos_y += (yMargin * 2 + height);
                return panels;
            }
            else
                return null;
        }
        public Panel[] CreatePanels(int totalCount, int colCount, int x, int xMargin, int yMargin, int height, int width, ref Label SemipersonalLabel)
        {
            int personalPanelsCount = 10;
            if (sections != null)
            {
                int pos_x;
                int pos_y = 0;
                int y;
                FlowLayoutPanel[] personalPanels = PersonalPanels(personalPanelsCount, colCount, x, 100, xMargin, yMargin, height, width, ref pos_y);
                if (personalPanels == null)
                {
                    PersonalLabel.Visible = false;
                    y = PersonalLabel.Location.Y+50;
                }
                else
                    y = pos_y;
                SemipersonalLabel = new Label();
                Controls.Add(SemipersonalLabel);
                SemipersonalLabel.AutoSize = true;
                SemipersonalLabel.Font = new Font("Arial", 18, FontStyle.Bold);
                SemipersonalLabel.Location = new Point(x, y - yMargin);
                SemipersonalLabel.Text = "Полуперсональные рекомендации";
                FlowLayoutPanel[] panels = new FlowLayoutPanel[totalCount];
                int rowCount;
                if (totalCount % colCount == 0)
                    rowCount = totalCount / colCount;
                else
                    rowCount = totalCount / colCount + 1;

                DeletePanels();
                for (int i = 0; i < rowCount; i++)
                {
                    pos_y = y + (yMargin + height) * i;
                    for (int j = 0; j < colCount; j++)
                    {
                        int k = i * colCount + j;
                        if (k >= totalCount)
                            return panels;
                        pos_x = x + (xMargin + width) * j;
                        panels[k] = CreatePanel(this, k, pos_x, pos_y, height, width);
                    }
                }
                if (personalPanels != null)
                    panels = personalPanels.Concat(panels).ToArray();
                return panels;
            }
            else
                return null;
        }

        public void ShowDetails(object sender, EventArgs e, int sectionIndex, int y)
        {
            string queryString = $"insert into Rating (regUser_id, section_id, explicit_, rating_weight, rating_type, rating_date) values ({currUser.id}, {sections[sectionIndex].id}, 0, 3, 'подробнее', GETDATE());";
            SqlCommand command = new SqlCommand(queryString, authWnd.dataBase.GetConnection());
            authWnd.dataBase.OpenConnection();
            command.ExecuteNonQuery();
            authWnd.dataBase.CloseConnection();
            int pos_y = 0;
            SectionWnd sectionWnd = new SectionWnd();
            sectionWnd.mainWnd = this;
            sectionWnd.section_id = sections[sectionIndex].id;
            sectionWnd.wishlist = sections[sectionIndex].wishlist;
            sectionWnd.pos_x = panels[sectionIndex].Location.X;
            sectionWnd.pos_y = y;
            sectionWnd.height = panels[sectionIndex].Height;
            sectionWnd.width = panels[sectionIndex].Width;
            sectionWnd.BackColor = Color.FromArgb(210, 245, 255);

            Label HeadingLabel = new Label();
            HeadingLabel.AutoSize = true;
            HeadingLabel.Dock = DockStyle.Top;
            HeadingLabel.TextAlign = ContentAlignment.TopCenter;
            HeadingLabel.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            pos_y += HeadingLabel.Height + 5;

            Label ShortInfoLabel = new Label();
            ShortInfoLabel.AutoSize = true;
            ShortInfoLabel.Font = new Font("Segoe UI", 12);
            ShortInfoLabel.Location = new Point(0, pos_y);
            pos_y += ShortInfoLabel.Height + 5;

            Label CostPerMonthLabel = new Label();
            CostPerMonthLabel.AutoSize = true;
            CostPerMonthLabel.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            CostPerMonthLabel.Location = new Point(0, pos_y);
            pos_y += CostPerMonthLabel.Height + 5;

            System.Windows.Forms.TextBox DescriptionBox = new System.Windows.Forms.TextBox();
            DescriptionBox.Font = new Font("Segoe UI", 9);
            DescriptionBox.ReadOnly = true;
            DescriptionBox.ScrollBars = ScrollBars.Both;
            DescriptionBox.Size = new Size(sectionWnd.Width - 10, sectionWnd.Height - 400);
            DescriptionBox.MaximumSize = new Size(sectionWnd.Width - 10, sectionWnd.Height - 400);
            DescriptionBox.Multiline = true;
            DescriptionBox.Location = new Point(0, pos_y);
            pos_y += DescriptionBox.Height + 5;

            Label ContactsLabel = new Label();
            ContactsLabel.AutoSize = true;
            ContactsLabel.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            ContactsLabel.Location = new Point(0, pos_y);

            sectionWnd.Controls.Add(HeadingLabel);
            sectionWnd.Controls.Add(ShortInfoLabel);
            sectionWnd.Controls.Add(CostPerMonthLabel);
            sectionWnd.Controls.Add(DescriptionBox);
            sectionWnd.Controls.Add(ContactsLabel);

            HeadingLabel.Text = sections[sectionIndex].name;
            AddStarToLabel(sectionWnd.StarLabel, sectionIndex);
            ShortInfoLabel.Text = sections[sectionIndex].sport + ", " + sections[sectionIndex].minAge.ToString() + "-" + sections[sectionIndex].maxAge.ToString() + " лет, " + sections[sectionIndex].location;
            CostPerMonthLabel.Text = sections[sectionIndex].cost.ToString() + " р./месяц, " + sections[sectionIndex].lessonsPerWeek.ToString() + " занятий в неделю";
            DescriptionBox.Text = sections[sectionIndex].description;
            ContactsLabel.Text = "email: " + sections[sectionIndex].contacts;
            sectionWnd.Show();
        }

        //используется при обновлении данных о пользователе в окне EditUserInfo
        public void LoadUserData()
        {
            string queryString = $"select * from RegUser where email ='{currUser.email}'";
            SqlCommand command = new SqlCommand(queryString, authWnd.dataBase.GetConnection());
            authWnd.dataBase.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                authWnd.LoadUserData(reader, currUser);
            }

            authWnd.dataBase.CloseConnection();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MainWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.authWnd.Show();
        }

        private void закрытьПрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.authWnd.Close();
        }

        private void MainWnd_Load(object sender, EventArgs e)
        {
            if (currUser.email == "admin")
                AnalyticsButton.Enabled = true;
            SemipersonalLabel = new Label();
            Controls.Add(SemipersonalLabel);
            users = LoadUsers();
            sections = LoadSections();
            ratings = LoadRatings(30);
            UpdateRecommendationsButton_Click(UpdateRecommendationsButton, e);
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            EditUserInfo editInfoWnd = new EditUserInfo();
            editInfoWnd.mainWnd = this;
            editInfoWnd.Show();
            ProfileButton.Enabled = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.Show();
        }

        private void UpdateRecommendationsButton_Click(object sender, EventArgs e)
        {
            if (MLRecommendationsBox.Checked || RegressionButton.Checked || ContentFilterButton.Checked)
            {
                UpdateRecommendationsButton.Enabled = false;
                WelcomeLabel.Text = "Добро пожаловать, " + currUser.name + "!";
                SectionsRelevance();
                Controls.Remove(SemipersonalLabel);
                panels = CreatePanels(50, 5, 280, 40, 30, 280, 250, ref SemipersonalLabel);
                MessageBox.Show("Рекомендации обновлены.");
                UpdateRecommendationsButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("Выберите режим работы рекомендаций", "Предупреждение");
            }
        }

        private void TrainModelButton_Click(object sender, EventArgs e)
        {
            TrainModelButton.Enabled = false;
            TrainMLModel(20, 100);
            MessageBox.Show("Обучение модели завершено.");

            TrainModelButton.Enabled = true;
        }

        private void OnlineFilterBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OnlineFilterBox.Checked)
            {
                UserFilterBox.Enabled = true;
                SectionFilterBox.Enabled = true;
            }
            else
            {
                SectionFilterBox.Enabled = false;
                ContentFilterButton.Checked = false;
                RegressionButton.Checked = false;
                UserFilterBox.Enabled = false;
            }
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            ChangePassword changeWnd = new ChangePassword();
            changeWnd.mainWnd = this;
            changeWnd.Show();
        }

        private void AnalyticsButton_Click(object sender, EventArgs e)
        {
            Analytics analyticsWnd = new Analytics();
            analyticsWnd.mainWnd = this;
            analyticsWnd.Show();
        }

        private void ContentFilterButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ContentFilterButton.Checked)
                UserFilterBox.Enabled = false;
            else
                UserFilterBox.Enabled = true;
        }
        //______________________________________________________________________________________________________________________________
    }
}
