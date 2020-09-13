using DevExpress.ExpressApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Hide controllers

namespace MainDemo.Module.BusinessObjects
{

    public interface IModelCustomOptions : IModelNode
    {
        [Category("Custom ListView")]
        bool ShowCancelActionListView { get; set; }

        [Category("Custom DetailView")]
        bool ShowDeleteActionDetailView { get; set; }

        [Category("Custom ListView")]
        [DefaultValue(true)]
        bool ShowEditAction { get; set; }

        [Category("Custom DetailView")]
        bool ShowFilterActionsDetailView { get; set; }

        [Category("Custom Global")]
        [DefaultValue(true)]
        bool ShowFullTextFilterAction { get; set; }

        [Category("Custom DetailView")]
        bool ShowNavigationActionsDetailView { get; set; }

        [Category("Custom Global")]
        [DefaultValue(true)]
        bool ShowOpenObjectAction { get; set; }

        [Category("Custom DetailView")]
        bool ShowResetViewSettingsActionDetailView { get; set; }

        [Category("Custom DetailView")]
        bool ShowSaveActionDetailView { get; set; }

        [Category("Custom ListView")]
        bool ShowSaveActionsListView { get; set; }

        [Category("Custom DetailView")]
        bool ShowSaveAndNewActionDetailView { get; set; }

        [Category("Custom Global")]
        bool ShowSvgSkinAction { get; set; }

        [Category("Custom Global")]
        bool BlockNewObject { get; set; }

        [Category("Custom DetailView")]
        bool ShowValidateAction { get; set; }
    }


    public interface IModelGridListEditorOptions
    {
        [Category("Custom ListView")]
        [DefaultValue(true)]
        bool EnableAppearanceOddRow { get; set; }

        [Category("Custom ListView")]
        [DefaultValue(true)]
        bool FreezeFirstColumn { get; set; }
    }

    public interface IModelAllowFilteringCriterion : IModelNode
    {
        [Category("Custom Filter")]
        [DefaultValue(true)]
        bool PokazujFiltryNaWydruku { get; set; }

        [Category("Custom Filter")]
        [DefaultValue(true)]
        bool WlaczFiltry { get; set; }
    }

    public interface IModelColorTabs : IModelNode
    {
        [Description("Odpowiada za kolorowanie zakładek z jednego wątku na jeden kolor.")]
        [Category("Custom colors")]
        [DefaultValue(true)]
        bool KolorujZakladki { get; set; }
    }
}
