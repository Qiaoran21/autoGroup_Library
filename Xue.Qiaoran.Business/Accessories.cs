/*
 * Name: Qiaoran Xue
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2023-02-27
 * Updated: 2023-02-27
 */

namespace Xue.Qiaoran.Business
{
    /// <summary>
    /// The accessories options for the vehicle.
    /// </summary>
    public enum Accessories
    {
        /// <summary>
        /// The stereo system accessory.
        /// </summary>
        StereoSystem = 0,

        /// <summary>
        /// The leather interior accessory.
        /// </summary>
        LeatherInterior = 1,

        /// <summary>
        /// The stereo system and leather interior accessories.
        /// </summary>
        StereoAndLeather = 2,

        /// <summary>
        /// The computer navigation accessory.
        /// </summary>
        ComputerNavigation = 3,

        /// <summary>
        /// The stereo system and computer navigation accessories.
        /// </summary>
        StereoAndNavigation = 4,

        /// <summary>
        /// The leather interior and computer navigation accessories.
        /// </summary>
        LeatherAndNavigation = 5,

        /// <summary>
        /// All the accessories.
        /// </summary>
        All = 6,

        /// <summary>
        /// None of the accessories.
        /// </summary>
        None = 7
    }
}