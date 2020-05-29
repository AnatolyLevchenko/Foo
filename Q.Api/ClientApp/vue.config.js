module.exports = {
    outputDir: "../wwwroot/dist",
    publicPath: "/dist/",
    filenameHashing: false,
    devServer: {
        proxy: {
            '/': {
                target: 'http://localhost:51062',
              //  ws: true,
                changeOrigin: true
            },
           

        },
        open: true,
    }
}
