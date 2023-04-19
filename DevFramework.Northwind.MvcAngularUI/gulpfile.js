/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var ts = require('gulp-typescript');
var clean = require('gulp-clean');

var destPath = './libs/';



// delete the dis directory
gulp.task('clean', async function () {
    return gulp.src(destPath)
        .pipe(clean());
});

gulp.task("scriptsNStyles", async function () {
    gulp.src([
        'core-js/client/*.js',
        'systemjs/dist/*.js',
        'reflect-metadata/*.js',
        'rxjs/**',
        'zone.js/dist/*.js',
        '@angular/**/bundles/*.js',
        'bootstrap/dist/js/*.js'
    ], {
        cwd: "node-modules/**"
    })
        .pipe(gulp.dest("./libs"));
});

var tsProject = ts.createProject('tsScripts/src/tsconfig.json', {
    typescript: require('typescript')
});

gulp.task('ts', async function (done) {
    // var tsResult = tsProject.src()
    var tsResult = gulp.src([
        "tsScripts/**/*.ts"
    ])
        .pipe(tsProject(), undefined, ts.reporter.fullReporter());
    return tsResult.js.pipe(gulp.dest('./Scripts'));
});


gulp.task('default', async function () {
    // place code for your default task here
});


