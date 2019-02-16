﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGraph
{
    public interface Listener
    {
        void Notify(params object[] messages);
        void NotifyMove(Room room);
    }

    public class Listeners
    {
        public List<Listener> listeners;
        public Listeners()
        {
            listeners = new List<Listener>();
        }
    }

    public class TargetListeners : Listeners, Listener
    {
        public void Notify(params object[] messages)
        {
            throw new NotImplementedException();
        }

        public void NotifyMove(Room room)
        {
            foreach (var item in listeners)
            {
                item.NotifyMove(room);
            }
        }
    }
}