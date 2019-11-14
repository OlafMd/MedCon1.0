'use strict';

var gulp = require('gulp');
var usemin = require('gulp-usemin');
var uglify = require('gulp-uglify');
var inject = require('gulp-inject');
var cacheBuster = require('gulp-cache-bust');
var del = require('del');
var templateCache = require('gulp-angular-templatecache');


var paths = {
    sass: ['./scss/**/*.scss'],
    javascript: [
        './scripts/src/**/*.js',
        '!./scripts/src/resource_files/**/*.js'
    ],
    css: [
        './Content/**/*.css',
    ]
};

// -------------------------------------
// Tasks
// -------------------------------------
gulp.task('clean', function () {
    return del(['static-release']);
});

gulp.task('cache-templates', function () {
    return gulp.src('scripts/**/*.html')
      .pipe(templateCache({ module: 'templates', standalone: true, root: 'scripts/' }))
      .pipe(gulp.dest('scripts/src/common/view'));
});

gulp.task('inject-static', function () {
    return gulp
        .src('./index.html')
        .pipe(inject(
            gulp.src(paths.javascript,
                { read: false }), { relative: true }))
        .pipe(gulp.dest('.'))
        .pipe(cacheBuster())
        .pipe(gulp.dest('.'))
        .pipe(inject(
            gulp.src(paths.css,
                { read: false }), { relative: true }))
        .pipe(gulp.dest('.'));
});

gulp.task('inject-static-with-templates', ['cache-templates'], function () {
    return gulp
        .src('./index.html')
        .pipe(inject(
            gulp.src(paths.javascript,
                { read: false }), { relative: true }))
        .pipe(gulp.dest('.'))
        .pipe(cacheBuster())
        .pipe(gulp.dest('.'))
        .pipe(inject(
            gulp.src(paths.css,
                { read: false }), { relative: true }))
        .pipe(gulp.dest('.'));
});

gulp.task('build', ['clean', 'inject-static-with-templates'], function () {
    return gulp.src('./index.html')
        .pipe(usemin({
            lib: [uglify()],
            app: [uglify()],
            translations: []
        }))
        .pipe(gulp.dest('static-release/'))
});


gulp.task('package', ['build'], function () {
    return gulp.src('static-release/index.html')
           .pipe(cacheBuster())
           .pipe(gulp.dest('static-release/'));
});

gulp.task('delete-template-cache', ['package'], function () {
    return del(['scripts/src/common/view/templates.js']);
});

gulp.task('inject-static-without-templates', ['delete-template-cache'], function () {
    return gulp
        .src('./index.html')
        .pipe(inject(
            gulp.src(paths.javascript,
                { read: false }), { relative: true }))
        .pipe(gulp.dest('.'))
        .pipe(cacheBuster())
        .pipe(gulp.dest('.'))
        .pipe(inject(
            gulp.src(paths.css,
                { read: false }), { relative: true }))
        .pipe(gulp.dest('.'));
});

gulp.task('release', ['inject-static-without-templates'], function () {

});