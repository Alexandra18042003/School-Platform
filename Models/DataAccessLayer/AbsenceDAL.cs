using Npgsql;
using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.DataAccessLayer
{
    public  class AbsenceDAL
    {
        public ObservableCollection<Absence> GetAllAbsences()
        {
            NpgsqlConnection con = DALHelper.Connection;


            NpgsqlCommand cmd = new NpgsqlCommand("GetAllAbsences", con);
            ObservableCollection<Absence> result = new ObservableCollection<Absence>();
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Absence p = new Absence();
                p.Absence_id = (int)(reader[0]);
                p.Student_id = (int)(reader[1]);
                p.CourseID = (int)(reader[2]);
                p.Checked_ = (bool)(reader[3]);
                p.Semester = (int)(reader[4]);

                result.Add(p);
            }
            reader.Close();
            con.Close();
            return result;
        }
    }
}
