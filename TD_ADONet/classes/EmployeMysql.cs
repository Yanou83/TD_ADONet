using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EmployeDatas.Mysql
{
    class EmployeMysql
    {
        private string host;
        private int port;
        private string db;
        private string login;
        private string pwd;
        private MySqlConnection connexion;

        public EmployeMysql(string host, int port, string db, string login, string pwd)
        {
            this.host = host;
            this.port = port;
            this.db = db;
            this.login = login;
            this.pwd = pwd;
            connexion = new MySqlConnection();
        }

        public void OuvrirMySql()
        {
            String cs = String.Format("Server = {0}; Port={1} ;Database = {2}; Uid = {3}; Pwd = {4}",host, port, db, login, pwd);

            connexion = new MySqlConnection(cs);
            connexion.Open();
            Console.WriteLine("Connecté à MySql");

        }

        public void FermerMySql()
        {
            String cs = String.Format("Data Source= " + "(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = {0})(PORT = {1}))" + "(CONNECT_DATA = (SERVICE_NAME = {2}))); User Id = {3}; Password = {4};", this.host, this.port, this.db, this.login, this.pwd);

            connexion = new MySqlConnection(cs);
            connexion.Close();
            Console.WriteLine("Déconnecté de MySql");
        }


        public void AfficherTousLesEmployes()
        {
            string requete = "SELECT employe.numemp, employe.nomemp, employe.prenomemp FROM employe";
            MySqlCommand mySqlCommand = new MySqlCommand(requete, connexion);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Int16 numero = reader.GetInt16(0);
                string nom = reader.GetString(1);
                string prenom = reader.GetString(2);
                Console.WriteLine("Numéro : {0} | Nom : {1} | Prénom : {2}", numero, nom, prenom);
            }
            reader.Close();
        }

        public void AfficherNbSeminaires()
        {
            string requete = "SELECT count(seminaire.codesemi) FROM seminaire";
            MySqlCommand mySqlCommand = new MySqlCommand(requete, connexion);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Int16 nbsemi = reader.GetInt16(0);
                Console.WriteLine("Nombre de séminaires : {0}",nbsemi);
            }
            reader.Close();
        }

        public void AfficherNbInscritsParCours()
        {
            string requete = "select seminaire.codecours, count(inscrit.numemp) from seminaire left join inscrit on inscrit.codesemi = seminaire.codesemi group by seminaire.codecours";
            MySqlCommand mySqlCommand = new MySqlCommand(requete, connexion);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                string nbemploye = reader.GetString(0);
                Int16 nbcours = reader.GetInt16(1);
                Console.WriteLine("Codecours : {0} | Nombre d'inscrits : {1} \n", nbemploye, nbcours);
            }
            reader.Close();
        }
    }
}
