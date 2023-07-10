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
    public class GradeDAL
    {
        public ObservableCollection<Grade> GetAllGrades()
        {
            NpgsqlConnection con = DALHelper.Connection;


            NpgsqlCommand cmd = new NpgsqlCommand("GetAllGrades", con);
            ObservableCollection<Grade> result = new ObservableCollection<Grade>();
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Grade p = new Grade();
                p.Grade_id = (int)(reader[0]);
                p.Student_id = (int)(reader[1]);
                p.Course_id = (int)(reader[2]);
                p.Grade_value = (int)(reader[3]);
                p.Semester = (int)(reader[4]);

                result.Add(p);
            }
            reader.Close();
            con.Close();
            return result;

            

        }
    }
}
