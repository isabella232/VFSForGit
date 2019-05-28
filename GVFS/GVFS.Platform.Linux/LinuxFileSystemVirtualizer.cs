using GVFS.Common;
using GVFS.Common.Git;
using GVFS.Platform.POSIX;
using PrjFSLib.Linux;
using PrjFSLib.POSIX;

namespace GVFS.Platform.Linux
{
    public class LinuxFileSystemVirtualizer : POSIXFileSystemVirtualizer
    {
        public LinuxFileSystemVirtualizer(GVFSContext context, GVFSGitObjects gitObjects)
            : this(context, gitObjects, virtualizationInstance: null)
        {
        }

        public LinuxFileSystemVirtualizer(
            GVFSContext context,
            GVFSGitObjects gitObjects,
            VirtualizationInstance virtualizationInstance)
            : base(context, gitObjects)
        {
            this.virtualizationInstance = virtualizationInstance ?? new LinuxVirtualizationInstance();
        }

        public override void Stop()
        {
            this.virtualizationInstance.StopVirtualizationInstance();
            base.Stop();
        }
    }
}
