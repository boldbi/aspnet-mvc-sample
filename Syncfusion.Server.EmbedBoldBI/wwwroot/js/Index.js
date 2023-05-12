function Init() {
    var http = new XMLHttpRequest();
    http.open("GET", getDashboardsUrl, true);
    http.responseType = 'json';
    http.setRequestHeader("Content-type", "application/json");
    http.onreadystatechange = function () {
        if (http.readyState == 4 && http.status == 200) {
            ListDashboards.call(this, typeof http.response == "object" ? http.response : JSON.parse(http.response));
        }
        else if (http.readyState == 4 && http.status == 404) {
            console.log("Server not found");
        }
        else if (http.readyState == 4) {
            console.log(http.statusText);
        }
    };
    http.send();
    };

    function ListDashboards(data) {
        if (typeof (data) != "undefined" && data != null) {
           renderDashboard(data[0].Id);
           data.forEach(function (element) {
               var divTag = document.createElement("div");
               divTag.innerHTML = element.Name;
               divTag.className = "dashboard-item";
               divTag.setAttribute("onclick", "renderDashboard('" + element.Id + "')");
               divTag.setAttribute("name", element.Name);
               divTag.setAttribute("itemid", element.Id);
               divTag.setAttribute("version", element.Version);
               divTag.setAttribute("ispublic", element.IsPublic);
               document.getElementById("panel").appendChild(divTag);
           });
           }
        }

        function renderDashboard(dashboardId) {
            var dashboard = BoldBI.create({
            serverUrl: rootUrl + "/" + siteIdentifier,//Dashboard Server BI URL (ex: http://localhost:5000/bi/site/site1, http://demo.boldbi.com/bi/site/site1)
            dashboardId: dashboardId,//Provide the dashboard id of the dashboard you want to embed here.  
            embedContainerId: "dashboard",//DOM id where the dashboard will be rendered, here it is dashboard.
            embedType: embedType.toLowerCase() == "component" ? BoldBI.EmbedType.Component : BoldBI.EmbedType.IFrame,
            environment: environment.toLowerCase() == "cloud" ? BoldBI.Environment.Cloud : BoldBI.Environment.Enterprise,//Your Bold BI application environment.
            width: "100%",
            height: "100%",
            mode: BoldBI.Mode.View,//Rendering mode of the dashboard can be Design and View for the dashboard.
            expirationTime: 100000,//Set the duration for the token to be alive.
                authorizationServer: {
                url: authorizationServerUrl //The URL from which particular dashboard details are obtained from the server.
                }
            
                });
     
                dashboard.loadDashboard();
        };