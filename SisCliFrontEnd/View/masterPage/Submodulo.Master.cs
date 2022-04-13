using Sistema.Api.dll.Repositorio.Util;
using Sistema.Api.dll.Src;
using Sistema.Api.dll.Template.GestaoNTIC.Master;
using System;

namespace Sistema.Web.UI.GestaoNTIC.View.masterPage
{
    public partial class SubModulo : CommonMasterPage
    {
        public GestaoNTICMasterTemplate MasterTemplate { get; set; }

        //Page_Load
        protected new virtual void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            SetTemplateSubmoduloMaster();
        }

        //SetTemplateSubmoduloMaster
        public void SetTemplateSubmoduloMaster()
        {
            string urlModulo = GetUrlModulo();

            if (Dominio.AppState != Dominio.ApplicationState.Debug)
            {
                MasterTemplate = new GestaoNTICMasterTemplate(Sessao.IdCampus, urlModulo, Sessao.IdUsuario, Sessao.AcessoExterno)
                {
                    ImgLinhaTopoIcone = { Src = "/View/Img/icones/iconePortal.png" },
                    ATitle = { Title = "Gestão NTIC", Href = "../Page/UltimosAcessos.aspx", Text = "Gestão do NTIC" },
                    InicioTopo = { Style = "background-color:#527a7a;" },
                };
            }
            else
            {
                MasterTemplate = new GestaoNTICMasterTemplate(Dominio.IdCampusDebug, urlModulo, Dominio.IdUsuarioDebug, false)
                {
                    ImgLinhaTopoIcone = { Src = "/View/Img/icones/iconePortal.png" },
                    ATitle = { Title = "Gestão NTIC", Href = "../Page/UltimosAcessos.aspx", Text = "Gestão do NTIC" },
                    InicioTopo = { Style = "background-color:#527a7a;" },
                };
            }
        }

    }
}