using OKHOSTING.Core;
using OKHOSTING.ORM;
using OKHOSTING.ORM.Operations;
using OKHOSTING.ORM.UI;
using OKHOSTING.UI;
using OKHOSTING.UI.Media;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AirsoftDeliciasChihuahua.Standard
{
    public class DataAppController : OKHOSTING.ORM.UI.DataAppController
    {
        public DataAppController (IPage page) : base(page)
        {

        }

        IGrid gridMainHome = BaitAndSwitch.Create<IGrid>();

        protected override void OnStart()
        {
            Master = BaitAndSwitch.Create<IPanel>();
            Master.App = Page.App;

            //show master and detail in different user controls
            if (MasterDetail)
            {
                Detail = BaitAndSwitch.Create<IPanel>();
                Detail.App = Page.App;
            }
            //Show master and detail in the same user control
            else
            {
                Detail = Master;
                Master.CopySize(Page);
            }

            var header = CreateHeader();

            var grid = BaitAndSwitch.Create<IGrid>();
            grid.RowCount = 3; //header, content, footer
            grid.ColumnCount = 2;

            var homePersonalizado = HomePersonalizado();

            grid.SetContent(0, 0, header);
            grid.SetContent(1, 0, Master);
            grid.SetContent(2, 0, homePersonalizado);

            grid.SetColumnSpan(2, header);
            grid.SetColumnSpan(2, homePersonalizado);

            if (MasterDetail)
            {
                grid.SetContent(1, 1, Detail);
            }
            else
            {
                grid.SetColumnSpan(2, Master);
            }

            Home = CreateHome();
            Home.Start();

            Page.Title = Master.Title;
            Page.Content = grid;
        }

        protected override IImageButton CreateLogo()
        {
            var logo = BaitAndSwitch.Create<IImageButton>();
            logo.LoadFromBytes(Resources.Images.airsoft);
            logo.Click += logo_Click;
            logo.Width = 150;
            logo.Height = 150;

            return logo;
        }

        protected override void logo_Click(object sender, EventArgs e)
        {
            Master.Visible = false;
            gridMainHome.Visible = true;
        }

        private IControl HomePersonalizado()
        {
            gridMainHome.Visible = false;
            gridMainHome.ShowGridLines = true;
            gridMainHome.RowCount = 1;
            gridMainHome.ColumnCount = 6;

            ILabel lblNamePropietarioHeader = BaitAndSwitch.Create<ILabel>();
            lblNamePropietarioHeader.Text = "Nombre Completo";
            gridMainHome.SetContent(0, 0, lblNamePropietarioHeader);

            ILabel lblNumberPhoneHeader = BaitAndSwitch.Create<ILabel>();
            lblNumberPhoneHeader.Text = "Número de Telefono";
            gridMainHome.SetContent(0, 1, lblNumberPhoneHeader);

            ILabel lblDirectionHeader = BaitAndSwitch.Create<ILabel>();
            lblDirectionHeader.Text = "Dirección";
            gridMainHome.SetContent(0, 2, lblDirectionHeader);

            ILabel lblClubHeader = BaitAndSwitch.Create<ILabel>();
            lblClubHeader.Text = "Club";
            gridMainHome.SetContent(0, 3, lblClubHeader);

            ILabel lblModelReplicaHeader = BaitAndSwitch.Create<ILabel>();
            lblModelReplicaHeader.Text = "Modelo de la Replica";
            gridMainHome.SetContent(0, 4, lblModelReplicaHeader);

            ILabel lblNumberSerieReplicaHeader = BaitAndSwitch.Create<ILabel>();
            lblNumberSerieReplicaHeader.Text = "Número de Serie de la Replica";
            gridMainHome.SetContent(0, 5, lblNumberSerieReplicaHeader);

            gridMainHome.RowCount++;

            //Seteando el contenido del grid
            var dataTypePropietario = DataType<Propietario>.GetDataType();
            var dataTypeReplica = DataType<Replica>.GetDataType();

            using (var dataBase = BaitAndSwitch.Create<DataBase>())
            {
                var propietariosReplicas = dataBase.Select<PropietarioReplica>();

                foreach (var propietarioReplica in propietariosReplicas)
                {
                    var propietario = dataBase.Select<Propietario>(dataTypePropietario[m => m.Id], propietarioReplica.Propietario.Id).FirstOrDefault();
                    var replica = dataBase.Select<Replica>(dataTypeReplica[m => m.Id], propietarioReplica.Replica.Id).FirstOrDefault();

                    ILabel lblNamePropietario = BaitAndSwitch.Create<ILabel>();
                    lblNamePropietario.Text = propietario.NombreCompleto;
                    gridMainHome.SetContent(gridMainHome.RowCount - 1, 0, lblNamePropietario);

                    ILabel lblNumberPhone = BaitAndSwitch.Create<ILabel>();
                    lblNumberPhone.Text = propietario.Telefono;
                    gridMainHome.SetContent(gridMainHome.RowCount - 1, 1, lblNumberPhone);

                    ILabel lblDirection = BaitAndSwitch.Create<ILabel>();
                    lblDirection.Text = propietario.Direccion;
                    gridMainHome.SetContent(gridMainHome.RowCount - 1, 2, lblDirection);

                    ILabel lblClub = BaitAndSwitch.Create<ILabel>();
                    lblClub.Text = propietario.ClubPerteneciente;
                    gridMainHome.SetContent(gridMainHome.RowCount - 1, 3, lblClub);

                    ILabel lblModelReplica = BaitAndSwitch.Create<ILabel>();
                    lblModelReplica.Text = replica.Modelo;
                    gridMainHome.SetContent(gridMainHome.RowCount - 1, 4, lblModelReplica);

                    ILabel lblNumberSerieReplica = BaitAndSwitch.Create<ILabel>();
                    lblNumberSerieReplica.Text = replica.NumeroSerie;
                    gridMainHome.SetContent(gridMainHome.RowCount - 1, 5, lblNumberSerieReplica);

                    gridMainHome.RowCount++;
                }
            }

            return gridMainHome;
        }
    }
}
