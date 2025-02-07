﻿using System;

namespace Apizr.Caching.Attributes
{
    /// <summary>
    /// Tells Apizr to cache all methods returning result when decorating an interface or a specific one when decorating a method
    /// You have to provide an <see cref="ICacheHandler"/> mapping implementation to Apizr to use this feature
    /// </summary>
    public abstract class CacheAttributeBase : Attribute
    {
        /// <summary>
        /// This specific caching lifetime
        /// </summary>
        public TimeSpan? LifeSpan { get; protected set; }

        /// <summary>
        /// Define the caching behaviour (default: FetchOrGet = api data first otherwise cache)
        /// </summary>
        public CacheMode Mode { get; protected set; } = CacheMode.FetchOrGet;

        /// <summary>
        /// Tells Apizr to remove the cache on error
        /// </summary>
        public bool ShouldInvalidateOnError { get; protected set; }

        /// <summary>
        /// Cache with no specific lifetime, default FetchOrGet mode and no invalidation on error
        /// </summary>
        protected CacheAttributeBase()
        {
        }

        /// <summary>
        /// Cache with no specific lifetime, no invalidation on error but a specific cache mode
        /// </summary>
        /// <param name="mode">FetchOrGet returns fresh data when request succeed otherwise cached one, where GetOrFetch returns cached data if we get some otherwise fresh one</param>
        protected CacheAttributeBase(CacheMode mode)
        {
            Mode = mode;
        }

        /// <summary>
        /// Cache with default FetchOrGet mode, no invalidation on error but with a specific lifetime
        /// </summary>
        /// <param name="lifeSpanRepresentation">TimeSpan representation to parse</param>
        protected CacheAttributeBase(string lifeSpanRepresentation)
        {
            LifeSpan = TimeSpan.Parse(lifeSpanRepresentation);
        }

        /// <summary>
        /// Cache with no specific lifetime, default FetchOrGet mode but with or without invalidation on error
        /// </summary>
        /// <param name="shouldInvalidateOnError">Should invalidate on error</param>
        protected CacheAttributeBase(bool shouldInvalidateOnError)
        {
            ShouldInvalidateOnError = shouldInvalidateOnError;
        }

        /// <summary>
        /// Cache with a specific cache and mode specific lifetime, but no invalidation on error
        /// </summary>
        /// <param name="mode">FetchOrGet returns fresh data when request succeed otherwise cached one, where GetOrFetch returns cached data if we get some otherwise fresh one</param>
        /// <param name="lifeSpanRepresentation">TimeSpan representation to parse</param>
        protected CacheAttributeBase(CacheMode mode, string lifeSpanRepresentation)
        {
            Mode = mode;
            LifeSpan = TimeSpan.Parse(lifeSpanRepresentation);
        }

        /// <summary>
        /// Cache with a specific cache and invalidation on error, but no specific lifetime
        /// </summary>
        /// <param name="mode">FetchOrGet returns fresh data when request succeed otherwise cached one, where GetOrFetch returns cached data if we get some otherwise fresh one</param>
        /// <param name="shouldInvalidateOnError">Should invalidate on error</param>
        protected CacheAttributeBase(CacheMode mode, bool shouldInvalidateOnError)
        {
            Mode = mode;
            ShouldInvalidateOnError = shouldInvalidateOnError;
        }

        /// <summary>
        /// Cache with a specific lifetime and invalidation on error, but default FetchOrGet mode
        /// </summary>
        /// <param name="lifeSpan">This specific caching lifetime</param>
        /// <param name="shouldInvalidateOnError">Should invalidate on error</param>
        protected CacheAttributeBase(TimeSpan lifeSpan, bool shouldInvalidateOnError)
        {
            LifeSpan = lifeSpan;
            ShouldInvalidateOnError = shouldInvalidateOnError;
        }

        /// <summary>
        /// Cache with a specific cache mode, a specific lifetime and invalidation on error
        /// </summary>
        /// <param name="mode">FetchOrGet returns fresh data when request succeed otherwise cached one, where GetOrFetch returns cached data if we get some otherwise fresh one</param>
        /// <param name="lifeSpanRepresentation">This specific caching lifetime</param>
        /// <param name="shouldInvalidateOnError">Should invalidate on error</param>
        protected CacheAttributeBase(CacheMode mode, string lifeSpanRepresentation, bool shouldInvalidateOnError)
        {
            Mode = mode;
            LifeSpan = TimeSpan.Parse(lifeSpanRepresentation);
            ShouldInvalidateOnError = shouldInvalidateOnError;
        }

        protected CacheAttributeBase(CacheMode mode, TimeSpan? lifeSpan, bool shouldInvalidateOnError)
        {
            Mode = mode;
            LifeSpan = lifeSpan;
            ShouldInvalidateOnError = shouldInvalidateOnError;
        }
    }
}
