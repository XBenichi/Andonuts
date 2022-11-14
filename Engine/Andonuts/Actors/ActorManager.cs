using System;
using System.Collections.Generic;
using System.Linq;

namespace Andonuts.Actors
{
    public class ActorManager
    {
        private List<Actor> actors;
        private Stack<Actor> actorsToAdd;
        private Stack<Actor> actorsToRemove;

        public ActorManager()
        {
            actors = new List<Actor>();
            actorsToAdd = new Stack<Actor>();
            actorsToRemove = new Stack<Actor>();
        }

        public void Add(Actor actor) => actorsToAdd.Push(actor);

        public void AddAll<T>(List<T> addActors) where T : Actor
        {
            int count = addActors.Count;
            for (int index = 0; index < count; ++index)
                Add((Actor)addActors[index]);
        }

        public void Remove(Actor actor) => actorsToRemove.Push(actor);

        public Actor Find(Func<Actor, bool> predicate) => actors.FirstOrDefault<Actor>(predicate);

        public void Step()
        {
            for (int index = actors.Count - 1; index >= 0; --index)
            {
                actors[index].Input();
                actors[index].Update();
            }
            actors.AddRange(actorsToAdd);
            actorsToAdd.Clear();
            while (actorsToRemove.Count > 0)
            {
                Actor actor = actorsToRemove.Pop();
                actor.Dispose();
                actors.Remove(actor);
            }
            actorsToRemove.Clear();
        }

        public void Clear()
        {
            for (int index = 0; index < actors.Count; ++index)
                actorsToRemove.Push(actors[index]);
        }
    }
}
