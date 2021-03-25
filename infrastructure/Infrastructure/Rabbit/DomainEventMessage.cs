﻿using System;
using System.Collections.Generic;
using System.Linq;
using Force.Ddd.DomainEvents;

namespace Infrastructure.Rabbit
{
    public class DomainEventMessage
    {
        public DomainEventMessage(IDomainEvent domainEvent)
        {
            if (domainEvent == null)
            {
                throw new ArgumentNullException(nameof(domainEvent));
            }

            EventType = domainEvent.GetType().FullName;

            var properties = domainEvent
                .GetType()
                .GetProperties()
                .Where(x => x.CanRead)
                .ToList();

            foreach (var p in properties)
            {
                this[p.Name] = p.GetValue(domainEvent);
            }
        }

        public string EventType { get; }

        public Dictionary<string, object> Data = new();

        public object this[string key]
        {
            get => Data.ContainsKey(key) == true ? Data[key] : default;
            set
            {
                Data[key] = value;
            }
        }
    }
}