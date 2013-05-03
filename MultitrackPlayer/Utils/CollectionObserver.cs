using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

namespace MultitrackPlayer.Utils
{
    public class CollectionObserver
    {
        private static int GetIndex<TSource>(ObservableCollection<TSource> source, Func<TSource, bool> filter, int sourceIndex)
        {
            if (filter == null)
                return sourceIndex;
            int index = 0;
            for (int i = 0; i < sourceIndex; i++)
                if (filter(source[i]))
                    index++;
            return index;
        }

        private static bool Filter<TSource>(Func<TSource, bool> filter, TSource item)
        {
            if (filter == null)
                return true;
            return filter(item);
        }

        public static NotifyCollectionChangedEventHandler BindCollection<TTarget, TSource>(ObservableCollection<TTarget> target, ObservableCollection<TSource> source, Func<TSource, TTarget> transform)
        {
            return BindCollection(target, source, null, transform);
        }

        public static NotifyCollectionChangedEventHandler BindCollection<TTarget, TSource>(ObservableCollection<TTarget> target, ObservableCollection<TSource> source, Func<TSource, bool> filter, Func<TSource, TTarget> transform)
        {
            target.Clear();
            foreach (var i in source)
                if (Filter(filter, i))
                    target.Add(transform(i));
            var handler = new NotifyCollectionChangedEventHandler(
            (o, e) =>
            {
                var action = new Action(() =>
                {
                    switch (e.Action)
                    {
                        case NotifyCollectionChangedAction.Add:
                            for (int itemIndex = 0; itemIndex < e.NewItems.Count; itemIndex++)
                            {
                                if (Filter(filter, (TSource)e.NewItems[itemIndex]))
                                    target.Insert(GetIndex(source, filter, e.NewStartingIndex + itemIndex), transform((TSource)e.NewItems[itemIndex]));
                            }
                            break;
                        case NotifyCollectionChangedAction.Move:
                            for (int itemIndex = 0; itemIndex < e.NewItems.Count; itemIndex++)
                            {
                                if (Filter(filter, (TSource)e.NewItems[itemIndex]))
                                    target.Move(GetIndex(source, filter, e.OldStartingIndex + itemIndex), GetIndex(source, filter, e.NewStartingIndex + itemIndex));
                            }
                            break;
                        case NotifyCollectionChangedAction.Remove:
                            for (int itemIndex = 0; itemIndex < e.OldItems.Count; ++itemIndex)
                            {
                                if (Filter(filter, (TSource)e.OldItems[itemIndex]))
                                {
                                    int indexToRemoveAt = GetIndex(source, filter, e.OldStartingIndex);
                                    if (target.Count <= indexToRemoveAt)
                                        break;
                                    target.RemoveAt(indexToRemoveAt);
                                }
                            }
                            break;
                        case NotifyCollectionChangedAction.Replace:
                            for (int itemIndex = 0; itemIndex < e.NewItems.Count; ++itemIndex)
                            {
                                if (Filter(filter, (TSource)e.OldItems[itemIndex]))
                                    target.RemoveAt(GetIndex(source, filter, e.NewStartingIndex + itemIndex));
                                if (Filter(filter, (TSource)e.NewItems[itemIndex]))
                                    target.Insert(GetIndex(source, filter, e.NewStartingIndex + itemIndex), transform((TSource)e.NewItems[itemIndex]));
                            }
                            break;
                        case NotifyCollectionChangedAction.Reset:
                            target.Clear();
                            foreach (var i in source)
                                if (Filter(filter, i))
                                    target.Add(transform(i));
                            break;
                    }
                });
                if (Application.Current.Dispatcher.Thread == System.Threading.Thread.CurrentThread)
                    action();
                else
                    Application.Current.Dispatcher.Invoke(action);
            });

            source.CollectionChanged += handler;

            return handler;
        }

    }
}
