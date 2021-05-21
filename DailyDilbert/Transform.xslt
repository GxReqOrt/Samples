<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >
	<xsl:output method="html" encoding="UTF-8"/>
	<xsl:template match="/">
		<html>
			<body>
				<xsl:value-of disable-output-escaping="yes" select="/rss/channel/item/description" />
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>