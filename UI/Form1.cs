using System.Diagnostics;
using TimeTable.UI;

namespace TimeTable
{
    public partial class Form1 : Form
    {
        LoginPage loginPage;
        SignUpPage signUpPage;
        SideBar sideBar;
        SideBarTop sideBarTop;
        DailyTaskPage dailyTaskPage;
        TaskLibraryPage taskLibraryPage;
        SubjectLibraryPage subjectLibraryPage;
        ReportStatsPage reportStatsPage;
        SettingsPage settingsPage;
        TimerPage timerPage;
        AddNewSubjectPage addNewSubjectPage;
        AddNewTaskPage addNewTaskPage;
        TaskDetailPage taskDetailPage;

        public Form1()
        {
            InitializeComponent();

            loginPage = new LoginPage(); 
            signUpPage = new SignUpPage();
            
        }

        public void InitialiseUserControls()
        {
            sideBar = new SideBar();
            sideBarTop = new SideBarTop();
            dailyTaskPage = new DailyTaskPage();
            taskLibraryPage = new TaskLibraryPage();
            subjectLibraryPage = new SubjectLibraryPage();
            reportStatsPage = new ReportStatsPage();
            settingsPage = new SettingsPage();
            timerPage = new TimerPage();
            addNewSubjectPage = new AddNewSubjectPage();
            addNewTaskPage = new AddNewTaskPage();
            taskDetailPage = new TaskDetailPage();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLoginPage();
            MinSideBar();
        }
        private void LoadLoginPage()  // requre the user to login before accessing the app
        {
            panelMain.Controls.Clear();
            loginPage.Dock = DockStyle.Fill;
            panelMain.Controls.Add(loginPage);
            Debug.WriteLine("Login Page Loaded");
            //subscribe to when login is successful
            loginPage.SignUpClicked += LoadSignUpPage;
            InitialiseUserControls();
            loginPage.LoginSuccessful += OnLoginSuccess;
            
        }
        private int _currentUserId;

        private void OnLoginSuccess(object? sender, LoginSuccessEvent e)
        {
            _currentUserId = e.userId;

            LoadSideBarBottom();
            LoadSideBarTop();
            MinSideBar();
            LoadDailyTaskPage();

            InitialiseUserControls();
        }


        private void LoadSignUpPage()
        {
            panelMain.Controls.Clear();
            signUpPage.Dock = DockStyle.Fill;
            panelMain.Controls.Add(signUpPage);
            Debug.WriteLine("Sign Up Page Loaded");

            signUpPage.LoginClicked += LoadLoginPage;

        }

        private void LoadSideBarBottom()
        {
            panelSideBottom.Controls.Clear();
            sideBar.Dock = DockStyle.Fill;
            panelSideBottom.Controls.Add(sideBar);

            //subscribe to when setting button in sidebar got click
            sideBar.DailyTaskButtonClicked += LoadDailyTaskPage;
            sideBar.ReportStatButtonClicked += LoadReportStatsPage;
            sideBar.SettingButtonClicked += LoadSettingPage;
            sideBar.SubjectLibraryButtonClicked += LoadSubjectLibraryPage;
            sideBar.TaskLibraryButtonClicked += LoadTaskLibraryPage;
        }
        private void LoadSideBarTop()
        {
            panelSideTop.Controls.Clear();
            sideBarTop.Dock = DockStyle.Fill;
            panelSideTop.Controls.Add(sideBarTop);

            sideBarTop.MinSideBarButtonClicked += MinSideBar;
        }
        private void MinSideBar()
        {
            if (panelSideBottom.Width >= 150) //sidebar
            {
                panelSideBottom.Width = 0;
            }
            else
            {
                panelSideBottom.Width = 150;
            }

            if (panelSide.Width >= 150) // sidebar main
            {
                panelSide.Width = 50;
            }
            else
            {
                panelSide.Width = 150;
            }

            if (panelSideTop.Width >= 150) //sidebar top
            {
                panelSideTop.Width = 50;
            }
            else
            {
                panelSideTop.Width = 150;
            }
        }

        private void LoadDailyTaskPage()
        {
            panelMain.Controls.Clear();
            dailyTaskPage.Dock = DockStyle.Fill;
            panelMain.Controls.Add(dailyTaskPage);
            Debug.WriteLine("Daily Task Page Loaded");
        }
        private void LoadTaskLibraryPage()
        {
            panelMain.Controls.Clear();
            taskLibraryPage.Dock = DockStyle.Fill;
            panelMain.Controls.Add(taskLibraryPage);
        }
        private void LoadSubjectLibraryPage()
        {
            panelMain.Controls.Clear();
            subjectLibraryPage.Dock = DockStyle.Fill;
            panelMain.Controls.Add(subjectLibraryPage);

            subjectLibraryPage.AddSubjectButtonClicked += LoadAddNewSubjectPage;
        }
        private void LoadReportStatsPage()
        {
            panelMain.Controls.Clear();
            reportStatsPage.Dock = DockStyle.Fill;
            panelMain.Controls.Add(reportStatsPage);
            Debug.WriteLine("Report / Stats Page Loaded");
        }
        private void LoadSettingPage()
        {
            panelMain.Controls.Clear();
            settingsPage.Dock = DockStyle.Fill;
            panelMain.Controls.Add(settingsPage);
        }
        private void LoadTimerPage()
        {
            panelMain.Controls.Clear();
            timerPage.Dock = DockStyle.Fill;
            panelMain.Controls.Add(timerPage);
        }
        private void LoadAddNewSubjectPage()
        {   
            panelMain.Controls.Clear();
            addNewSubjectPage.Dock = DockStyle.Fill;
            panelMain.Controls.Add(addNewSubjectPage);
        }
        private void LoadAddNewTaskPage()
        {
            panelMain.Controls.Clear();
            addNewTaskPage.Dock = DockStyle.Fill;
            panelMain.Controls.Add(addNewTaskPage);

        }
        private void LoadTaskDetailPage()
        {
            panelMain.Controls.Clear();
            taskDetailPage.Dock = DockStyle.Fill;
            panelMain.Controls.Add(taskDetailPage);
        }
    }
}
