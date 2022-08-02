// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Timing;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Graphics.Containers;

namespace osu.Game.Beatmaps
{
    /// <summary>
    /// Provides various data sources which allow for synchronising visuals to a known beat.
    /// Primarily intended for use with <see cref="BeatSyncedContainer"/>.
    /// </summary>
    [Cached]
    public interface IBeatSyncProvider : IHasAmplitudes
    {
        /// <summary>
        /// Check whether beat sync is currently available.
        /// </summary>
        public bool BeatSyncAvailable => Clock != null;

        /// <summary>
        /// Whether the beat sync provider is currently in a kiai section. Should make everything more epic.
        /// </summary>
        public bool IsKiaiTime => Clock != null && (ControlPoints?.EffectPointAt(Clock.CurrentTime).KiaiMode ?? false);

        /// <summary>
        /// Access any available control points from a beatmap providing beat sync. If <c>null</c>, no current provider is available.
        /// </summary>
        ControlPointInfo? ControlPoints { get; }

        /// <summary>
        /// Access a clock currently responsible for providing beat sync. If <c>null</c>, no current provider is available.
        /// </summary>
        IClock? Clock { get; }
    }
}
