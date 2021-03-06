var jsonfile = require('jsonfile');
var util = require('util');

var file = 'src\\Loggly.Extensions.Logging\\project.json';
var buildNumber = process.env.APPVEYOR_BUILD_VERSION;

jsonfile.readFile(file,
    function(err, project) {
        //console.log(project);
        //console.log(err);
        project.version = buildNumber;

        jsonfile.writeFile(file,
            project,
            { spaces: 2 },
            function(err) {
                console.error(err);
            });
    });