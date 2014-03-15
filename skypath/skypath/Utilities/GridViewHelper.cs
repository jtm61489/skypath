using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace skypath.Utilities
{
    public class GridViewHelper
    {

        public static int GetColumnID(string columnName, GridView gridView)
        {
            int columnID = -1;

            foreach (DataControlField column in gridView.Columns)
            {
                if (column.HeaderText == columnName)
                {
                    columnID = gridView.Columns.IndexOf(column);
                }
            }

            return columnID;
        }

        public static int GetGridViewInt(GridViewRow gvr, int columnIndex)
        {
            int returnValue = -1;

            returnValue = int.Parse(gvr.Cells[columnIndex].Text);

            return returnValue;
        }
    }
}