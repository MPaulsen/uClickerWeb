﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UClickerWeb
{
    //dbControls
    //This class is for establishing a connection with the CBA database
    //and performing general database functions (queries/non-queries) as needed
    //by other classes.
    static class dbControls
    {
        #region Generalized database functions
        //Generalized database functions
        //The following four functions are for running database commands or 
        //querying the related databases.  They are used by the other Controls classes.

        public static String getConnectionString()
        {
            return "Server=184.88.49.211;Database=uClicker;User Id=Taylias;Password=prower;";
        }

        public static String dbQuery(string query)
        {
            SqlConnection con = new SqlConnection(getConnectionString());
            SqlCommand cmd = new SqlCommand(query, con);
            object returnValue;

            using (con)
            {
                if (con.State == ConnectionState.Open)
                    returnValue = cmd.ExecuteScalar();
                else
                {
                    con.Open();
                    returnValue = cmd.ExecuteScalar();
                }
                con.Close();
            }

            if (returnValue == null)
                return "";
            else return returnValue.ToString();
        }

        public static void dbNonQuery(string query)
        {
            SqlConnection con = new SqlConnection(getConnectionString());
            SqlCommand cmd = new SqlCommand(query, con);

            using (con)
            {
                if (con.State == ConnectionState.Open)
                    cmd.ExecuteScalar();
                else
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static Hashtable Select(String qS)
        {
            Hashtable hTable = new System.Collections.Hashtable();

            SqlConnection con = new SqlConnection(getConnectionString());
            SqlCommand cmd = new SqlCommand(qS, con);
            SqlDataReader datReader;

            using (con)
            {
                if (con.State == ConnectionState.Open)
                    datReader = cmd.ExecuteReader();
                else
                {
                    con.Open();
                    datReader = cmd.ExecuteReader();
                }

                if (datReader.HasRows)
                {
                    int i = 0;
                    while (datReader.Read())
                    {
                        hTable.Add(i, datReader[0].ToString());
                        i++;
                    }

                    con.Close();
                }
                else
                {
                    con.Close();
                }
            }

            return hTable;
        }

        #endregion
    }
}