<?xml version="1.0" encoding="utf-8" ?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<head>
			<title>Violations Report</title>
			<style type="text/css">
				h1 { color: #444444 }
				caption { font-weight: bold; color: #444444; background: #EEEEEE }
			</style>
		</head>

		<html>
			<body>
				<h1>Violations Report</h1>
		
				<xsl:for-each select="Violations/File">
          <xsl:sort select="@Path" />
					<br/>
					
					<table width="800" border="0" cellpadding="2" cellspacing="1">
						<caption align="left"><xsl:value-of select="@Path"/></caption>
						<tr bgcolor="#BEBBD1">
							<th align="left">Col</th>
							<th align="left">Row</th>
							<th align="left">Rule Type</th>
							<th align="left">Description</th>
						</tr>
						
						<xsl:for-each select="Violation">
							<xsl:sort select="@Type" />
		
							<xsl:variable name="rowColor">
								<xsl:choose>
									<xsl:when test="(position() mod 2)=0">#DFDCE1</xsl:when>  
									<xsl:otherwise>#D6D6DC</xsl:otherwise>
								</xsl:choose>
							</xsl:variable>
							
							<tr bgcolor="{$rowColor}">
								<td>
									<xsl:value-of select="@Column"/>
								</td>
								<td>
									<xsl:value-of select="@Row"/>
								</td>
								<td>
									<xsl:value-of select="@Type"/>
								</td>
								<td>
									<xsl:value-of select="."/>
								</td>
							</tr>
						</xsl:for-each>
					</table>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>