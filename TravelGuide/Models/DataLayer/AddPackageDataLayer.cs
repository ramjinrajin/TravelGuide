using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelGuide.infrastructure;
using TravelGuide.Models.Properties.CountryTouristModel;
using System.Data;
using System.Data.SqlClient;

namespace TravelGuide.Models.DataLayer
{
    public class AddPackageDataLayer
    {
        public ResponseType SavePackage(CountryTourist objCountryTourist)
        {

            using (SqlConnection con = new SqlConnection(ConnectMSSql.GetConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SpAddPackage", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CountryName", objCountryTourist._Country.CountryName);
                    cmd.Parameters.AddWithValue("@CountryLatitude", objCountryTourist._Country.Latitude);
                    cmd.Parameters.AddWithValue("@CountryLongitude", objCountryTourist._Country.Longitude);

                    cmd.Parameters.AddWithValue("@PlaceName", objCountryTourist._Touristplace.PlaceName);
                    cmd.Parameters.AddWithValue("@PlaceLongitude", objCountryTourist._Touristplace.Longitude);
                    cmd.Parameters.AddWithValue("@PlaceLatitude", objCountryTourist._Touristplace.Latitude);

                    int Result = (int)cmd.ExecuteScalar();
                    if (Result == (int)ResponseType.Sucess)
                    {
                        return ResponseType.Sucess;
                    }
                    else
                    {
                        return ResponseType.Exists;
                    }

                }
                catch (Exception)
                {

                    return ResponseType.Error;
                }
                finally
                {
                    con.Close();
                }
            }



        }

    }
}