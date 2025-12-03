#define FIREBASE

#if MYSQL
    using DbConnection = MySql.Data.MySqlClient.MySqlConnection;
    using DbCommand = MySql.Data.MySqlClient.MySqlCommand;
    using DbDataReader = MySql.Data.MySqlClient.MySqlDataReader;
    using DbConnectionStringBuilder = MySql.Data.MySqlClient.MySqlConnectionStringBuilder;
#elif POSTGRESQL
#elif MSSQL
    using DbConnection = Microsoft.Data.SqlClient.SqlConnection;
    using DbCommand = Microsoft.Data.SqlClient.SqlCommand;
    using DbDataReader = Microsoft.Data.SqlClient.SqlDataReader;
    using DbConnectionStringBuilder = Microsoft.Data.SqlClient.SqlConnectionStringBuilder;
#elif FIREBASE
using Firebase.Database;
using Firebase.Database.Query;
#endif


using EntityLayer;


namespace DataLayer
{


    public static class DL
    {

#if MYSQL || MSSQL

        static DbConnection conn = new DbConnection(
            new DbConnectionStringBuilder()
            {
#if MYSQL
                Server = "10.111.0.180",
                Database = "rehberdb",
                UserID = "root",
                Password = "wfnxy123",
                Port = 3306,
#elif MSSQL
                DataSource = "10.111.0.180",
                InitialCatalog = "mydatabase",
                UserID = "myuser",
                Password = "mypassword", 
#endif
            }.ConnectionString);

        public static DbConnection GetConnection()
        {
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            return conn;
        }

        public static void CloseConnection()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
        }
#elif FIREBASE
        const string ConnectionString = "https://rehber2025-cdaf0-default-rtdb.firebaseio.com/";
        static FirebaseClient firebaseClient = new FirebaseClient(ConnectionString);

        class FirebaseKisi
        {
            public string Id { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Email { get; set; }
            public string Telefon { get; set; }
            public string ResimData { get; set; }


            public static FirebaseKisi FromKisi(Kisi k)
            {
                return new FirebaseKisi()
                {
                    Id = k.Id,
                    Ad = k.Ad,
                    Soyad = k.Soyad,
                    Telefon = k.Telefon,
                    Email = k.Email,
                    ResimData = k.ResimData
                };
            }
        }

#endif


        public static int KisiEkle(Kisi k, out string message)
        {
#if FIREBASE
            try
            {
                message="";
                firebaseClient.Child($"kisiler/{k.Id}").PutAsync(FirebaseKisi.FromKisi(k)).Wait();
                return 1;
            }
            catch(Exception ex)
            {
                message = ex.Message;
                return 0;
            }

#else

            try
            {
                if (string.IsNullOrEmpty(k.Id) ||
                    string.IsNullOrEmpty(k.Ad) ||
                    string.IsNullOrEmpty(k.Soyad))
                {
                    message = "Id, Ad ve Soyad alanları boş olamaz.";
                    return 0;
                }

                DbCommand komut = new DbCommand("INSERT INTO kisiler VALUES(@Id, @Ad, @So, @Em, @Tl, @Re)", GetConnection());
                komut.Parameters.AddWithValue("@Id", k.Id);
                komut.Parameters.AddWithValue("@Ad", k.Ad);
                komut.Parameters.AddWithValue("@So", k.Soyad);

                if (string.IsNullOrEmpty(k.Email))
                    komut.Parameters.AddWithValue("@Em", DBNull.Value);
                else
                    komut.Parameters.AddWithValue("@Em", k.Email);

                if (string.IsNullOrEmpty(k.Telefon))
                    komut.Parameters.AddWithValue("@Tl", DBNull.Value);
                else
                    komut.Parameters.AddWithValue("@Tl", k.Telefon);

                if (string.IsNullOrEmpty(k.ResimData))
                    komut.Parameters.AddWithValue("@Re", DBNull.Value);
                else
                    komut.Parameters.AddWithValue("@Re", k.ResimData);

                message = "Kişi başarıyla eklendi.";
                return komut.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
                return 0;
            }
            finally
            {
                // bağlantının kapatılmasını garantiler.
                CloseConnection();
            }
#endif
        }

        public static int KisiDuzenle(Kisi k, out string message)
        {
#if FIREBASE
            try
            {
                message = "";
                firebaseClient.Child($"kisiler/{k.Id}").PatchAsync(FirebaseKisi.FromKisi(k)).Wait();
                return 1;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return 0;
            }

#else

            try
            {
                if (string.IsNullOrEmpty(k.Id) ||
                    string.IsNullOrEmpty(k.Ad) ||
                    string.IsNullOrEmpty(k.Soyad))
                {
                    message = "Id, Ad ve Soyad alanları boş olamaz.";
                    return 0;
                }

                DbCommand komut = new DbCommand(
                    "UPDATE kisiler " +
                       " SET Ad = @_ad, " +
                       "     Soyad = @So, " +
                       "     Email = @Em," +
                       "     Telefon = @Tl," +
                       "     Resim = @Re " +
                       " WHERE Id = @id", GetConnection());

                komut.Parameters.AddWithValue("@_ad", k.Ad);
                komut.Parameters.AddWithValue("@So", k.Soyad);

                if (string.IsNullOrEmpty(k.Email))
                    komut.Parameters.AddWithValue("@Em", DBNull.Value);
                else
                    komut.Parameters.AddWithValue("@Em", k.Email);

                if (string.IsNullOrEmpty(k.Telefon))
                    komut.Parameters.AddWithValue("@Tl", DBNull.Value);
                else
                    komut.Parameters.AddWithValue("@Tl", k.Telefon);

                if (string.IsNullOrEmpty(k.ResimData))
                    komut.Parameters.AddWithValue("@Re", DBNull.Value);
                else
                    komut.Parameters.AddWithValue("@Re", k.ResimData);

                komut.Parameters.AddWithValue("@id", k.Id);


                message = "Kişi başarıyla güncellendi.";
                return komut.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
                return 0;
            }
            finally
            {
                // bağlantının kapatılmasını garantiler.
                CloseConnection();
            }
#endif
        }

        public static int KisiSil(string id, out string message)
        {
#if FIREBASE
            try
            {
                message = "";
                firebaseClient.Child($"kisiler/{id}").DeleteAsync().Wait();
                return 1;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return 0;
            }

#else

            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    message = "Böyle bir kişi yok!";
                    return 0;
                }

                DbCommand komut = new DbCommand(
                    "DELETE FROM kisiler " +
                       " WHERE Id = @id", GetConnection());
                komut.Parameters.AddWithValue("@id", id);

                message = "Kişi başarıyla silindi.";
                return komut.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
                return 0;
            }
            finally
            {
                // bağlantının kapatılmasını garantiler.
                CloseConnection();
            }
#endif
        }

        public static List<Kisi> KisileriYukle(string filter, out string message)
        {
            List<Kisi> liste = new List<Kisi>();
#if FIREBASE
            try
            {
                message = "";
                var res = firebaseClient.Child("kisiler").OnceAsync<FirebaseKisi>();

                foreach (var k in res.Result)
                   liste.Add(new Kisi()
                   {
                       Id = k.Object.Id,
                       Ad = k.Object.Ad,
                       Soyad = k.Object.Soyad,
                       Email = k.Object.Email,
                       Telefon = k.Object.Telefon,
                       ResimData = k.Object.ResimData,
                   });

                return liste;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }

#else

            try
            {
                string komutText;
                if (string.IsNullOrEmpty(filter))
                {
                    komutText = "SELECT * FROM kisiler ORDER BY Ad, Soyad";
                }
                else
                {
                    komutText = $"SELECT * FROM kisiler " +
                                $" WHERE Ad LIKE %{filter}% " +
                                $"    OR Soyad LIKE %{filter}% " +
                                $"    OR Email LIKE %{filter}% " +
                                $"    OR Telefon LIKE %{filter}% ";
                }

                DbCommand komut = new DbCommand(komutText, GetConnection());

                message = $"{liste.Count} kişi bulundu.";
                DbDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    liste.Add(new Kisi()
                    {
                        Id = reader["Id"].ToString(),
                        Ad = reader["Ad"].ToString(),
                        Soyad = reader["Soyad"].ToString(),
                        Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                        Telefon = reader["Telefon"] == DBNull.Value ? null : reader["Telefon"].ToString(),
                        ResimData = reader["Resim"] == DBNull.Value ? null : reader["Resim"].ToString(),
                    });
                }

                return liste;
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
                return null;
            }
            finally
            {
                // bağlantının kapatılmasını garantiler.
                CloseConnection();
            }
#endif
        }
    }
}
