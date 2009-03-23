class ZipTools

  require 'find'
  require 'zip/zip'

  def self.create_zip(filename, root, excludes=/^$/)
    File.delete(filename) if File.exists? filename
    Zip::ZipFile.open(filename, Zip::ZipFile::CREATE) do |zip|
      Find.find(root) do |path|
        next if path =~ excludes
      
        zip_path = path.gsub(root, '')
        zip.add(zip_path, path)
      end
    end
  end
  
end