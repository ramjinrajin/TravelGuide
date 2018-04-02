using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelGuide.Models.Properties.SearchModel;
using System.Data;
using System.Data.SqlClient;
using TravelGuide.infrastructure;
using TravelGuide.Models.Properties.TouristplaceModel;

namespace TravelGuide.Models.DataLayer
{
    public class IterateDataLayer
    {

        public SearchResult GetLatandLog(Search objSearch)
        {
            SearchResult objSearchResult = new SearchResult();
            using (SqlConnection con = new SqlConnection(ConnectMSSql.GetConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select  top 2 * from tblCountry where CountryName in (@Source,@Designation) ORDER by Longitude asc", con);
                    cmd.Parameters.AddWithValue("@Source", objSearch.Source);
                    cmd.Parameters.AddWithValue("@Designation", objSearch.Designation);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        int i = 0;
                        while (rdr.Read())
                        {
                            if (i == 0)
                            {
                                objSearchResult.SourceLatitude = rdr["Longitude"].ToString();
                            }
                            else
                            {
                                objSearchResult.DesignationLongitude = rdr["Longitude"].ToString();
                            }

                            i++;
                        }
                    }

                }
                catch (Exception)
                {


                }
                finally
                {
                    con.Close();
                }
            }
            return objSearchResult;
        }

        public List<Touristplace> ListPlaces(SearchResult objSearchResult)
        {
            List<Touristplace> objListPlaces = new List<Touristplace>();

            using (SqlConnection con = new SqlConnection(ConnectMSSql.GetConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select   * from tblTouristplace where  Longitude BETWEEN 760000 AND 779999", con);
                    //cmd.Parameters.AddWithValue("@Source", objSearchResult.SourceLatitude);
                    //cmd.Parameters.AddWithValue("@Designation", objSearchResult.DesignationLongitude);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        
                        while (rdr.Read())
                        {
                            Touristplace objTouristplace = new Touristplace
                            {
                                Description = rdr["Description"].ToString(),
                                PhotoPath = rdr["PhotoPath"].ToString(),
                                PlaceName = rdr["PlaceName"].ToString() 
                              
                            };

                            objListPlaces.Add(objTouristplace);
                        }
                    }

                }
                catch (Exception)
                {


                }
                finally
                {
                    con.Close();
                }
            }

            


            return objListPlaces;


        }

    }
}