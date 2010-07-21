class ZipTools

  require 'find'
  require 'zip/zip'

  def self.create_zip(new_zip_file, root)
	Zip::ZipFile.open(new_zip_file, Zip::ZipFile::CREATE) do |zipfile|
		Find.find(root) do |path|
			Find.prune if File.basename(path)[0] == ?.
			dest = /Package\/(\w.*)/.match(path)
			zipfile.add(dest[1],path) if dest
		end
	end
  end
  
end