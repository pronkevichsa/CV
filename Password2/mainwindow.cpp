#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    trayIcon = new QSystemTrayIcon(this);
    trayIcon->setIcon(this->style()->standardIcon(QStyle::SP_ComputerIcon)); //SP_ComputerIcon
    trayIcon->setToolTip("Tray Program" "\n" "Работа со сворачиванием программы трей");
    /* After that create a context menu of two items */
    QMenu * menu = new QMenu(this);
    QAction * viewWindow = new QAction(trUtf8("Развернуть окно"), this);
    QAction * quitAction = new QAction(trUtf8("Выход"), this);
    /* connect the signals clicks on menu items to by appropriate slots.
         * The first menu item expands the application from the tray,
         * And the second menu item terminates the application
         * */
    connect(viewWindow, SIGNAL(triggered()), this, SLOT(show()));
    connect(quitAction, SIGNAL(triggered()), this, SLOT(close()));
    menu->addAction(viewWindow);
    menu->addAction(quitAction);
    /* Set the context menu on the icon
         * And show the application icon in the system tray
         * */
    trayIcon->setContextMenu(menu);
    trayIcon->show();
    /* Also connect clicking on the icon to the signal processor of this press * */
    connect(trayIcon, SIGNAL(activated(QSystemTrayIcon::ActivationReason)),this, SLOT(iconActivated(QSystemTrayIcon::ActivationReason)));

    ui->setupUi(this);

    mydb=QSqlDatabase::addDatabase("QSQLITE");
    mydb.setDatabaseName("company.db");

   // mydb.setDatabaseName("e:/Serge/_Programming/Password2/company.db");

    if (mydb.open())
    {
        ui->label->setText("Connected");
        ui->progressBar->setValue(50);
    }
    else {
        ui->label->setText("db open error");
    }
}

MainWindow::~MainWindow()
{

    delete ui;
}

void MainWindow::iconActivated(QSystemTrayIcon::ActivationReason reason)
{
    qDebug()<<"iconActivated";
    this->show();
    QWidget::showNormal();
}

void MainWindow::closeEvent(QCloseEvent *event)
{
     event->accept();
}

void MainWindow::hideEvent(QHideEvent *event)
{
    event->ignore();
    if(this->isVisible())
    {
        event->ignore();
        this->hide();
        QSystemTrayIcon::MessageIcon icon = QSystemTrayIcon::MessageIcon(QSystemTrayIcon::Information);
        trayIcon->showMessage("Tray Program",
                              trUtf8("Приложение свернуто в трей. Для того чтобы, "
                                     "развернуть окно приложения, щелкните по иконке приложения в трее"),
                              icon, 2000);
    }
}

void MainWindow::on_pushButton_Login_clicked()
{
    QString username, password;
    username = ui->lineEdit_username->text();
    password = ui->lineEdit_password->text();

    if (!mydb.isOpen())
    {
        qDebug()<<"Failed to open database";
        return;
    }
    else
    {
        QSqlQuery qry;
        QString querystring = "select * from employee where name ='"+username+ "' and password = '"+password+"'";
        if (qry.exec(querystring))
        {
            qDebug()<<"qry";
            int count=0;
            while(qry.next())
            {
                count++;
            }
            if (count==1)
            {
                ui->label->setText("username and password is correct");
                ui->progressBar->setValue(100);
            }
            else
            {
                 qDebug()<<"error count";
                ui->label->setText("username and password is incorrect");
            }
        }
        else
        {
            qDebug()<<"error query";
        }
    }
}

