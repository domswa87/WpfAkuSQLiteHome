using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.Models.Calculator
{
    public class UnlikeQiLogic
    {
        UnlikeQiModel unlikeQiModel;

        public UnlikeQiModel FillUnlikeQiModel(GraphModel graphModel)
        {
            unlikeQiModel = new UnlikeQiModel();

            unlikeQiModel.BigLetterInput = "k";
            unlikeQiModel.BigLetterDown = "d";
            unlikeQiModel.BigLetterUp = "k";
            unlikeQiModel.SmallLetterInput = "k";
            unlikeQiModel.SmallLetterUp = "k";
            unlikeQiModel.SmallLetterDown = "k";
            unlikeQiModel.SmallLetterDownR = "k";
            unlikeQiModel.SmallLetterDownL = "k";

            return unlikeQiModel;
        }
     
    }
}
