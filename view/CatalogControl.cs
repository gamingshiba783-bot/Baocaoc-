using System.Drawing;
using System.Windows.Forms;

namespace Baibaocao.net.view
{
    /// <summary>Trang Danh mục: gồm 3 tab con Thể loại / Tác giả / Nhà xuất bản.</summary>
    public class CatalogControl : UserControl
    {
        private readonly TabControl tabs = new TabControl { Dock = DockStyle.Fill };
        private readonly CategoryControl categoryControl = new CategoryControl { Dock = DockStyle.Fill };
        private readonly AuthorControl authorControl = new AuthorControl { Dock = DockStyle.Fill };
        private readonly PublisherControl publisherControl = new PublisherControl { Dock = DockStyle.Fill };

        public CatalogControl()
        {
            Size = new Size(783, 412);

            var pgCategory = new TabPage("Thể loại");
            var pgAuthor = new TabPage("Tác giả");
            var pgPublisher = new TabPage("Nhà xuất bản");
            pgCategory.Controls.Add(categoryControl);
            pgAuthor.Controls.Add(authorControl);
            pgPublisher.Controls.Add(publisherControl);
            tabs.TabPages.AddRange(new[] { pgCategory, pgAuthor, pgPublisher });
            tabs.SelectedIndexChanged += (s, e) => RefreshData();

            Controls.Add(tabs);
        }

        public void RefreshData()
        {
            switch (tabs.SelectedIndex)
            {
                case 0: categoryControl.RefreshData(); break;
                case 1: authorControl.RefreshData(); break;
                case 2: publisherControl.RefreshData(); break;
            }
        }
    }
}
