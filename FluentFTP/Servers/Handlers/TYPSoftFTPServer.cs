using FluentFTP.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace FluentFTP.Servers.Handlers {

	/// <summary>
	/// Server-specific handling for TYPSoft FTP Server
	/// </summary>
	internal class TYPSoftFTPServer : FtpBaseServer {

		/// <summary>
		/// Return the FtpServer enum value corresponding to your server, or Unknown if its a custom implementation.
		/// </summary>
		public override FtpServer ToEnum() {
			return FtpServer.TYPsoft;
		}

		/// <summary>
		/// Return true if your server is detected by the given FTP server welcome message.
		/// </summary>
		public override bool DetectByWelcome(string message) {

			// Detect TYPSoft FTP Server
			// Welcome message: "220 TYPSoft FTP Server 1.10 ready..."
			if (message.Contains("TYPSoft FTP Server")) {
				return true;
			}

			return false;
		}

		public override bool IsCustomGetAbsolutePath() {
			return true;
		}

		/// <summary>
		/// Perform server-specific path modification here.
		/// Return the absolute path.
		/// </summary>
		public override string GetAbsolutePath(FtpClient client, string path) {

			if (path == null || path.Trim().Length == 0) {
				path = "/";
			}

			return path;
		}

		public override Task<string> GetAbsolutePathAsync(AsyncFtpClient client, string path, CancellationToken token) {
			
			if (path == null || path.Trim().Length == 0) {
				path = "/";
			}

			return Task.FromResult(path);
		}

	}
}
