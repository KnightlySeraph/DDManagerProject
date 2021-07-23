using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDManagerSolution.Model
{
    public class Screen
    {

        #region Local

        private string _screenName;

        #endregion

        public Screen()
        {
            _screenName = "New Screen";
        }

        public void ScreenName(string screenName)
        {
            _screenName = screenName;
        }

        public string ScreenName()
        {
            return _screenName;
        }
    }
}
