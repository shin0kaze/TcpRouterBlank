using TcpRouter.Abstractions;

namespace TcpRouter.RouteManager.Tests {
	public class Tests {
		public RouteManager RouteManager { get; set; }

		[SetUp]
		public void Setup()
		{
			RouteManager = new();
		}

		[Test]
		public void add_route()
		{
			var expectedRoute = new Route(new("00001111222214"), new(ReadOnlyIPAddress.Parse("127.0.0.1"),6389));

			RouteManager.CreateNewRoute(expectedRoute);
			RouteManager.TryGetRoute(expectedRoute.SerialNumber, out var actualRoute);

			Assert.AreEqual(expectedRoute, actualRoute);
		}

		[Test]
		public void get_all_routes()
		{

			List<Route> initRoutes = new()
		{
		new (new("00001111222214"), new(ReadOnlyIPAddress.Parse("127.0.0.1"), 6389)),
		new (new("10001111222214"), new(ReadOnlyIPAddress.Parse("127.0.0.2"), 6389)),
		new (new("20001111222214"), new(ReadOnlyIPAddress.Parse("127.0.0.3"), 6389)),
		};
			List<RouteWithStatus> expectedRoutes = new()
		{
		new (initRoutes[0], false, false),
		new (initRoutes[1], false, false),
		new (initRoutes[2], false, false),
		};
			RouteManager.CreateNewRoute(initRoutes[0]);
			RouteManager.CreateNewRoute(initRoutes[1]);
			RouteManager.CreateNewRoute(initRoutes[2]);

			var actualRoutes = RouteManager.GetAllRoutes();
			Assert.True(actualRoutes.SequenceEqual(expectedRoutes));
			//Assert.AreEqual(expectedRoutes, actualRoutes);
		}
	}
}