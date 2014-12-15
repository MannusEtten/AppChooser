using System;
using System.Drawing;
using System.IO;
using System.ServiceProcess;
using System.Windows.Forms;

namespace EsriApplicationChooser
{
    internal class MenuCreator
    {
        private ContextMenuStrip _menu;

        internal void AddMenuItems(ContextMenuStrip contextMenuStrip1)
        {
            _menu = contextMenuStrip1;
            AddApplications();
            AddRule();
            AddUrls();
            AddRule();
            AddServices();
        }

        private void AddRule()
        {
            ToolStripSeparator separator = new ToolStripSeparator();
            _menu.Items.Add(separator);
        }

        private void AddServices()
        {
            Configuration config = Configuration.GetConfig();
            ToolStripLabel label = new ToolStripLabel();
            label.Text = "Services";
            Font f = new Font("tahoma", 8, FontStyle.Bold);
            label.Font = f;
            _menu.Items.Add(label);
            foreach (ServiceElement service in config.Services)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Text = service.Title;
                menuItem.Tag = service.Key;
                menuItem.Enabled = CheckEnabled(service);
                menuItem.Checked = CheckStatus(service);
                menuItem.Click += new EventHandler(MenuItemClick);
                _menu.Items.Add(menuItem);
            }
        }

        private bool CheckEnabled(ServiceElement service)
        {
            ServiceController myService = new ServiceController();
            myService.ServiceName = service.Name;
            try
            {
                var status = myService.Status;

            }
            catch (InvalidOperationException e)
            {
                return false;
            }
            return true;
        }

        private bool CheckStatus(ServiceElement service)
        {
            ServiceController myService = new ServiceController();
            myService.ServiceName = service.Name;
            try
            {
                if (myService.Status == ServiceControllerStatus.Stopped) { return false; }
                if (myService.Status == ServiceControllerStatus.Running) { return true; }
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
            return false;
        }

        private void AddUrls()
        {
            Configuration config = Configuration.GetConfig();
            ToolStripLabel label = new ToolStripLabel();
            label.Text = "Websites";
            Font f = new Font("tahoma", 8, FontStyle.Bold);
            label.Font = f;
            _menu.Items.Add(label);
            foreach (UrlElement service in config.Urls)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Text = service.Title;
                menuItem.Tag = service.Key;
                menuItem.Click += new EventHandler(MenuItemClick);
                _menu.Items.Add(menuItem);
            }
        }

        private void AddApplications()
        {
            Configuration config = Configuration.GetConfig();
            ToolStripLabel label = new ToolStripLabel();
            label.Text = "Applicaties";
            Font f = new Font("tahoma", 8, FontStyle.Bold);
            label.Font = f;
            _menu.Items.Add(label);
            foreach (ApplicationElement service in config.Applications)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Text = service.Title;
                menuItem.Tag = service.Key;
                menuItem.Enabled = CheckEnabled(service);
                menuItem.Click += new EventHandler(MenuItemClick);
                _menu.Items.Add(menuItem);
            }
        }

        private bool CheckEnabled(ApplicationElement service)
        {
            return File.Exists(service.Location);
        }

        private void MenuItemClick(object sender, EventArgs e)
        {
            string tag = (sender as ToolStripMenuItem).Tag.ToString();
            ClickHandler handler = new ClickHandler(tag);
            handler.HandleClick();
            SetStatusServices(tag);
        }

        private void SetStatusServices(string tag)
        {
            Configuration config = Configuration.GetConfig();
            for (int i = 0; i < _menu.Items.Count; i++)
            {
                object otag = _menu.Items[i].Tag;
                if (otag == null) { continue; }
                ServiceElement service = config.Services[tag.ToString()];
                if (service != null)
                {
                    if (otag.Equals(tag))
                    {
                        ToolStripMenuItem item = _menu.Items[i] as ToolStripMenuItem;
                        item.Checked = !item.Checked;
                    }
                }
                if (otag.Equals(tag)) { return; }
            }
        }
    }
}