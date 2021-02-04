using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.Core;
using OKHOSTING.ORM;

namespace AirsoftDeliciasChihuahua.Standard
{
    public class Home : Controller
    {
        public Home(IPage page) : base(page)
        {

        }

        IGrid gridMain = BaitAndSwitch.Create<IGrid>();

        protected override void OnStart()
        {
            gridMain.ShowGridLines = true;
            gridMain.RowCount = 1;
            gridMain.ColumnCount = 6;

            ILabel lblNamePropietarioHeader = BaitAndSwitch.Create<ILabel>();
            lblNamePropietarioHeader.Text = "Nombre Completo";
            gridMain.SetContent(0, 0, lblNamePropietarioHeader);

            ILabel lblNumberPhoneHeader = BaitAndSwitch.Create<ILabel>();
            lblNumberPhoneHeader.Text = "Número de Telefono";
            gridMain.SetContent(0, 1, lblNumberPhoneHeader);

            ILabel lblDirectionHeader = BaitAndSwitch.Create<ILabel>();
            lblDirectionHeader.Text = "Dirección";
            gridMain.SetContent(0, 2, lblDirectionHeader);

            ILabel lblClubHeader = BaitAndSwitch.Create<ILabel>();
            lblClubHeader.Text = "Club";
            gridMain.SetContent(0, 3, lblClubHeader);

            ILabel lblModelReplicaHeader = BaitAndSwitch.Create<ILabel>();
            lblModelReplicaHeader.Text = "Modelo de la Replica";
            gridMain.SetContent(0, 4, lblModelReplicaHeader);

            ILabel lblNumberSerieReplicaHeader = BaitAndSwitch.Create<ILabel>();
            lblNumberSerieReplicaHeader.Text = "Número de Serie de la Replica";
            gridMain.SetContent(0, 5, lblNumberSerieReplicaHeader);

            gridMain.RowCount++;

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
                    gridMain.SetContent(gridMain.RowCount - 1, 0, lblNamePropietario);

                    ILabel lblNumberPhone = BaitAndSwitch.Create<ILabel>();
                    lblNumberPhone.Text = propietario.Telefono;
                    gridMain.SetContent(gridMain.RowCount - 1, 1, lblNumberPhone);

                    ILabel lblDirection = BaitAndSwitch.Create<ILabel>();
                    lblDirection.Text = propietario.Direccion;
                    gridMain.SetContent(gridMain.RowCount - 1, 2, lblDirection);

                    ILabel lblClub = BaitAndSwitch.Create<ILabel>();
                    lblClub.Text = propietario.ClubPerteneciente;
                    gridMain.SetContent(gridMain.RowCount - 1, 3, lblClub);

                    ILabel lblModelReplica = BaitAndSwitch.Create<ILabel>();
                    lblModelReplica.Text = replica.Modelo;
                    gridMain.SetContent(gridMain.RowCount - 1, 4, lblModelReplica);

                    ILabel lblNumberSerieReplica = BaitAndSwitch.Create<ILabel>();
                    lblNumberSerieReplica.Text = replica.NumeroSerie;
                    gridMain.SetContent(gridMain.RowCount - 1, 5, lblNumberSerieReplica);

                    gridMain.RowCount++;
                }
            }

            Page.Content = gridMain;
        }
    }
}
