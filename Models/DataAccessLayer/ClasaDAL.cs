using Npgsql;
using SchoolPlatform.Models.EntityLayer;
using SchoolPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolPlatform.Models.DataAccessLayer
{
    public class ClasaDAL
    {
        public ObservableCollection<Clasa> GetAllClasses()
        {
            NpgsqlConnection con = DALHelper.Connection;

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("GetAllClasses", con);
                ObservableCollection<Clasa> result = new ObservableCollection<Clasa>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Clasa p = new Clasa();
                    p.Id = (int)(reader[0]);
                    p.AnStudiu = (int)(reader[1]);
                    p.ProfID = (int)(reader[2]);
                    p.DenumireSpecializare = reader.GetString(3);

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

        public void AddClass(Clasa c)
        {
            NpgsqlConnection con = DALHelper.Connection;

            NpgsqlCommand cmd = new NpgsqlCommand("AddClass", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramName = new NpgsqlParameter("in_an_studiu", NpgsqlTypes.NpgsqlDbType.Integer);
            paramName.Value = c.AnStudiu;

            NpgsqlParameter paramSecondName = new NpgsqlParameter("in_profesor_id", NpgsqlTypes.NpgsqlDbType.Integer);
            paramSecondName.Value = c.ProfID;

            NpgsqlParameter paramClasaID = new NpgsqlParameter("in_denumire_specializare", NpgsqlTypes.NpgsqlDbType.Varchar);
            paramClasaID.Value = c.DenumireSpecializare;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramSecondName);
            cmd.Parameters.Add(paramClasaID);

            con.Open();

            cmd.ExecuteNonQuery();

            MessageBox.Show("Class added successfully!");

            con.Close();

        }

        public void DeleteClass(Clasa c)
        {
            NpgsqlConnection con = DALHelper.Connection;
            NpgsqlCommand cmd = new NpgsqlCommand("DeleteClass", con);
            cmd.CommandType = CommandType.StoredProcedure;

            NpgsqlParameter paramID = new NpgsqlParameter("in_clasa_id", NpgsqlTypes.NpgsqlDbType.Integer);
            paramID.Value = c.Id;

            cmd.Parameters.Add(paramID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}
