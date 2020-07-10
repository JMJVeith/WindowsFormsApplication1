using System.ComponentModel;

namespace RealmWarsTestView
{
    class turnBackgroundWorker
    {
        private BackgroundWorker background_worker;
        private turnTimingBar progress_bar;

        public turnBackgroundWorker(BackgroundWorker background_worker, turnTimingBar progress_bar)
        {
            this.background_worker = background_worker;
            this.progress_bar = progress_bar;

            background_worker.DoWork += dowork_bar;
            background_worker.ProgressChanged += updateBar;
            background_worker.RunWorkerCompleted += updateBar;
            background_worker.WorkerReportsProgress = true;
        }

        private void dowork_bar(object sender, DoWorkEventArgs e)
        {
            //info should be sent from turn

            //while (timeline_wrapper.get_turn_percentage() < 100)
            //{
            //    turn_progress_worker.ReportProgress((int)timeline_wrapper.get_turn_percentage());//works
            //    Thread.Sleep(20);
            //}
        }

        public void run()
        {
            if (!background_worker.IsBusy)
            {
                background_worker.RunWorkerAsync();
            }
        }

        private void updateBar(object sender, ProgressChangedEventArgs e)
        {
            progress_bar.instant_update(e.ProgressPercentage);
        }

        private void updateBar(object sender, RunWorkerCompletedEventArgs e)
        {
            progress_bar.update();
        }

        public void dispose()
        {
            progress_bar.instant_update(0);
            background_worker.Dispose();
        }
    }
}
