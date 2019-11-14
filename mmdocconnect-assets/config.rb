# Require any additional compass plugins here.

# Set this to the root of your project when deployed:
http_path = ""
css_dir = "../mmdocconnect-resources/content/"
# fonts_dir = 'fonts/'
sass_dir = "/sass"
images_dir = "../mmdocconnect-resources/images/"
javascripts_dir = "../mmdocconnect-resources/scripts/"

# You can select your preferred output style here (can be overridden via the command line):
output_style = :expanded
#output_style = :compressed

# To enable relative paths to assets via compass helper functions. Uncomment:
relative_assets = true

# To disable debugging comments that display the original location of your selectors. Uncomment:
line_comments = false


# If you prefer the indented syntax, you might want to regenerate this
# project again passing --syntax sass, or you can uncomment this:
# preferred_syntax = :sass
# and then run:
# sass-convert -R --from scss --to sass sass scss && rm -rf sass && mv scss sass

require "json"
require "fileutils"

file = JSON.parse(File.read('dest.json'))

on_stylesheet_saved do |filename|
  if(file["dest"][filename] != nil)
    FileUtils.cp(filename, file["dest"][filename])
    puts "[sync] #{File.basename(filename)}"
  end
end
