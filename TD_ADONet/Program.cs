using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using MySql.Data.MySqlClient;
using EmployeDatas.Mysql;
using EmployeDatas.Oracle;


namespace TD_ADONet
{
    class Program
    {
        static void Main(string[] args)
        {
            //String host = "freesio.lyc-bonaparte.fr";
            String host = "10.10.2.10";
            int port = 1521;
            string sid = "slam";
            string login = "montenotado";
            string pwd = "sio";

            try
            {

                EmployeOracle cs1 = new EmployeOracle(host, port, sid, login, pwd);
                cs1.OuvrirOracle();


                //    //Console.WriteLine(cs1.AfficherTousLesCours());
                cs1.AfficherNbProjets();
                
                //    //cs1.AfficherSalaireMoyenParProjet();
                //cs1.AugmenterSalaireCurseur();
                //    //cs1.AfficherEmployesSalaire(125000);
                //    cs1.AfficheSalaireEmploye(1);
                //    ////cs1.InsereCours();
                //    ////cs1.SupprimeCours("BR099");
                //    //cs1.AugmenterSalaire(5, "PR2");


                cs1.FermerOracle();
            }
            catch (OracleException ex)
            {
                Console.WriteLine("Erreur Oracle " + ex.Message);
            }


            string hostMysql = "127.0.0.1";
            int portMysql = 3306;
            string baseMysql = "dbadonet";
            String uidMysql = "employeado";
            String pwdMysql = "s7syW3f2RD6cR4";
            try
            {
                EmployeMysql cs = new EmployeMysql(hostMysql, portMysql, baseMysql, uidMysql, pwdMysql);

                cs.OuvrirMySql();

                cs.AfficherTousLesEmployes();
                cs.AfficherNbSeminaires();
                cs.AfficherNbInscritsParCours();

                cs.FermerMySql();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
    
}