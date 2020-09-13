using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using MainDemo.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainDemo.Module.Controllers
{
    public partial class ListViewGlobalController : ViewController<ListView>
    {
        private IModelCustomOptions HideActionOptions => Application.Model.Options as IModelCustomOptions;

        protected override void OnActivated()
        {
            base.OnActivated();
            _VisibleHideAction();
        }

        private void _FilterControllerHideAction(FilterController filterController)
        {
            if (filterController == null ||
                Frame.Context == TemplateContext.LookupControl ||
                Frame.Context == TemplateContext.LookupWindow)
            {
                return;
            }

            filterController.FullTextFilterAction.Active.SetItemValue("Visible", HideActionOptions.ShowFullTextFilterAction);
        }

        private void _MofificationControllerHideAction(ModificationsController controller)
        {
            if (controller != null)
            {
                controller.SaveAction.Active.SetItemValue("Visible", HideActionOptions.ShowSaveActionsListView);
                controller.SaveAndCloseAction.Active.SetItemValue("Visible", HideActionOptions.ShowSaveActionsListView);
                controller.CancelAction.Active.SetItemValue("Visible", HideActionOptions.ShowCancelActionListView);
            }
        }

        private void _VisibleHideAction()
        {
            _MofificationControllerHideAction(Frame.GetController<ModificationsController>());
            _FilterControllerHideAction(Frame.GetController<FilterController>());
        }
    }
}
