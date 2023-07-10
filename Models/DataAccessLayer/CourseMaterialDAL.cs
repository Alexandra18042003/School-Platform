using Npgsql;
using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlatform.Models.DataAccessLayer
{
    public class CourseMaterialDAL
    {
        public ObservableCollection<CourseMaterial> GetAllCourseMaterial()
        {
            NpgsqlConnection con = DALHelper.Connection;

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("GetAllCourseMaterial", con);
                ObservableCollection<CourseMaterial> result = new ObservableCollection<CourseMaterial>();
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CourseMaterial p = new CourseMaterial();
                    p.CourseMaterialID = (int)(reader[0]);
                    p.CourseID = (int)(reader[1]);
                    p.Semester = (int)(reader[2]);
                    p.CourseMaterial_name = reader.GetString(3);

                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }

        }
    }
}
