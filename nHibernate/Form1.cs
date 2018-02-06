using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;



namespace nHibernate
{
    public partial class Form1 : Form
    {
        private Configuration  myConfiguration;
        private ISessionFactory  mySessionFactory;
        private ISession mySession;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myConfiguration = new Configuration();
            myConfiguration.Configure();
            mySessionFactory = myConfiguration.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();

            //Add Record
            using (mySession.BeginTransaction())
            {
                Contact loContact = new Contact {FirstName="John", LastName = "Doe" };
                mySession.Save(loContact);
                mySession.Transaction.Commit();   
            }

            //List Contact
            ICriteria critera = mySession.CreateCriteria<Contact>();
            IList<Contact> list = critera.List<Contact>();
            mySession.Transaction.Commit();
        }
    }
} 
