using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace OOP4200_Final_Project
{
    internal class DBAccess
    {
        #region "Connection String"
        /// <summary>
        /// Method to get the connection string to dbPokerLogs
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            return Properties.Settings.Default.ConnectionString;
        }

        #endregion

        #region "Methods"

        /// <summary>
        /// Database access method to insert a new record into the database 
        /// </summary>
        /// <param name="sql_insert_script"> The sql script to insert a new record</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        internal static Boolean InsertNewRecord(string winnerName, String winningHand, int amntWon, DateTime dateWon)
        {
            Boolean result = false;
            // Get the connection string and nonquery
            SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Winner_Logs VALUES (@Winner_Name, " +
                "@Winning_Hand_Combination, @Amount_Won, @Date_Won)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Winner_Name", winnerName);
            sqlCommand.Parameters.AddWithValue("@Winning_Hand_Combination", winningHand);
            sqlCommand.Parameters.AddWithValue("@Amount_Won", amntWon);
            sqlCommand.Parameters.AddWithValue("@Date_Won", dateWon);
            // Try to execute the insert statement
            try
            {
                sqlConnection.Open();
                result = (sqlCommand.ExecuteNonQuery() == 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
            
            return result;
        }


        #endregion


    }
}
