using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.WPF.ViewModels
{
    public class MajorIndexViewModel
    {
        private IMajorIndexService _majorIndexService;

        public MajorIndex Apple { get; set; }
        public MajorIndex Intel { get; set; }
        public MajorIndex Microsoft { get; set; }

        public MajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public static MajorIndexViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            var majorIndexViewModel = new MajorIndexViewModel(majorIndexService);
            majorIndexViewModel.LoadMajorIndexes();
            return majorIndexViewModel;
        }

        private void LoadMajorIndexes()
        {
            _majorIndexService.GetMajorIndex(MajorIndexType.AAPL).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Apple = task.Result;
                }
            });
            
            _majorIndexService.GetMajorIndex(MajorIndexType.INTC).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Intel = task.Result;
                }
            });

            _majorIndexService.GetMajorIndex(MajorIndexType.MSFT).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Microsoft = task.Result;
                }
            });
        }
    }
}