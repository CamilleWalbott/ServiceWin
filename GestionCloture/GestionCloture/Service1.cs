using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GestionCloture
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
           
        }
        //Pdo class
        Pdo pdo;
        Timer timer;
        protected override void OnStart(string[] args)
        {
           
            pdo = new Pdo("camillewyc01.mysql.db", 3306, "gsb_frais", "camillewyc021", "TestPPE2019");
            timer = new Timer();
            timer.Interval = 300000;
            timer.Elapsed += new ElapsedEventHandler(this.timer_Tick);

        }

        private void timer_Tick(object sender, ElapsedEventArgs e)
        {
            if (Dates.Between(01, 19))
            {
                int PreviousMonth = int.Parse(Dates.getPreviousMonth()); 
                pdo.update("fichefrais", "idetat", "CL", "idetat ='CR' AND mois LIKE '%"+PreviousMonth+"'");
            }

            if (Dates.Between(20, 30))
            {
                int PreviousMonth = int.Parse(Dates.getPreviousMonth());
                pdo.update("fichefrais", "idetat", "RB", "idetat ='CL' AND mois LIKE '%" + PreviousMonth + "'");
            }


        }

        protected override void OnStop()
        {
            pdo.Close();
        }

        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }
    }
}
