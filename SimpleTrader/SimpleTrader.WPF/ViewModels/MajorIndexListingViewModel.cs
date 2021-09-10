using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.WPF.ViewModels
{
    public class MajorIndexListingViewModel : ViewModelBase
    {
        private IMajorIndexService _majorIndexService;

        private MajorIndex _apple;
        public MajorIndex Apple
        {
            get => _apple;
            set
            {
                _apple = value;
                OnPropertyChanged();
            }
        }

        private MajorIndex _intel;
        public MajorIndex Intel
        {
            get => _intel;
            set
            {
                _intel = value;
                OnPropertyChanged();
            }
        }

        private MajorIndex _microsoft;
        public MajorIndex Microsoft
        {
            get => _microsoft;
            set
            {
                _microsoft = value;
                OnPropertyChanged();
            }
        }

        public MajorIndexListingViewModel(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public static MajorIndexListingViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            var majorIndexViewModel = new MajorIndexListingViewModel(majorIndexService);
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