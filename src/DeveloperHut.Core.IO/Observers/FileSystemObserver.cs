using System;
using System.IO;
using System.Reactive.Linq;

namespace DeveloperHut.Core.IO.Observers
{
    public sealed class FileSystemObserver : IDisposable
    {
        private readonly FileSystemWatcher _watcher = new FileSystemWatcher();

        public IObservable<FileSystemEventArgs> CreatedFiles { get; private set; }
        public IObservable<RenamedEventArgs> RenamedFiles { get; private set; }
        public IObservable<FileSystemEventArgs> ChangedFiles { get; private set; }
        public IObservable<FileSystemEventArgs> DeletedFiles { get; private set; }
        public IObservable<ErrorEventArgs> Errors { get; private set; }

        public FileSystemObserver(string directory, string filter = "", bool recurse = false)
        {
            _watcher.Path = directory;
            _watcher.Filter = filter;
            _watcher.IncludeSubdirectories = recurse;
            _watcher.EnableRaisingEvents = true;

            CreatedFiles = Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(handler => handler.Invoke, handler => _watcher.Created += handler, handler => _watcher.Created -= handler)
                                      .Select(x => x.EventArgs);

            RenamedFiles = Observable.FromEventPattern<RenamedEventHandler, RenamedEventArgs>(handler => handler.Invoke, handler => _watcher.Renamed += handler, handler => _watcher.Renamed -= handler)
                                     .Select(x => x.EventArgs);

            ChangedFiles = Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(handler => handler.Invoke, handler => _watcher.Changed += handler, handler => _watcher.Changed -= handler)
                                     .Select(x => x.EventArgs);

            DeletedFiles = Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(handler => handler.Invoke, handler => _watcher.Deleted += handler, handler => _watcher.Deleted -= handler)
                                     .Select(x => x.EventArgs);

            Errors = Observable.FromEventPattern<ErrorEventHandler, ErrorEventArgs>(handler => handler.Invoke, handler => _watcher.Error += handler, handler => _watcher.Error -= handler)
                               .Select(x => x.EventArgs);
        }

        public void Dispose()
        {
            _watcher.Dispose();
        }
    }
}
