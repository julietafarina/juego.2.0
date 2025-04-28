using juego.Models;
using System.Data.SqlClient;

namespace juego.Datos
{
    public class PlataformaDatos
    {
        private string conexionString = "Data Source=Julita;Initial Catalog=PlataformaJuegos;Integrated Security=True";

        public List<Juego> ListaJuegos(int id)
        {
            List<Juego> lista = new List<Juego>();
            using (SqlConnection con = new SqlConnection(conexionString))
            {

                
                string query = "SELECT Juego.Id as Id_Juego, Juego.Nombre as NombreJuego, Juego.Categoria, Juego.HorasJugadas, " +
                    "Desarrollador.Id as Id_Desarrollador, Desarrollador.Nombre as NombreDesarrollador " +
                    "FROM Juego join Desarrollador on Juego.Id_Desarrollador = Desarrollador.Id";

                if (id > 0)
                {
                    query += $" WHERE Juego.Id = {id}";
                }

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Juego()
                    {
                        Id = (int)reader["Id_Juego"],
                        Nombre = reader["NombreJuego"].ToString(),
                        Categoria = reader["Categoria"].ToString(),
                        HorasJugadas = (int)reader["HorasJugadas"],
                        Id_Desarrollador = (int)reader["Id_Desarrollador"],
                        Desarrollador = new Desarrollador()
                        {
                            Id = (int)reader["Id_Desarrollador"],
                            Nombre = reader["NombreDesarrollador"].ToString()
                        }
                    });
                }

            }
            return lista;

        }

        public string CrearJuego(Juego juego)
        {
            string query = $"INSERT INTO Juego (Nombre, Categoria, HorasJugadas, Id_Desarrollador) VALUES " +
                $"('{juego.Nombre}', '{juego.Categoria}', {juego.HorasJugadas}, {juego.Id_Desarrollador}) ";
            

            try
            {
                using (SqlConnection conn = new SqlConnection(conexionString))
                {
                    conn.Open();
                    SqlCommand cm = new SqlCommand(query, conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    return "";

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Desarrollador> listarDesarrollador(int id)
        {
            List<Desarrollador> list = new List<Desarrollador>();

            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                string _query = "Select * from Desarrollador";
                conn.Open();
                SqlCommand _cmd = new SqlCommand(_query, conn);
                SqlDataReader _reader = _cmd.ExecuteReader();
                while (_reader.Read())
                {
                    list.Add(new Desarrollador()
                    {
                        Id = (int)_reader["ID"],
                        Nombre = _reader["Nombre"].ToString(),
                    });
                }

                return list;
            }

        }
        public string EditarJuego(Juego juego)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(conexionString))
                {
                    string query = $"UPDATE Juego SET Nombre = '{juego.Nombre}', Id_Desarrollador = {juego.Id_Desarrollador}, Categoria = '{juego.Categoria}', HorasJugadas = {juego.HorasJugadas} where Id = {juego.Id} ";
                        
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }
        public string EliminarJuego(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexionString))
                {
                    string query = $" DELETE FROM Juego WHERE Id = {id}";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
    
}
