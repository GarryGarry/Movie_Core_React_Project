

module.exports = {
    mode: "development",
    context: __dirname,
    entry: {
        app: "./App.js"
    },
    output: {
        path: __dirname + "/dist",
        filename: "[name]_bundle.js"
    },
    watch: true,
    module: {
        rules: [
            {
                test: /\.(jpg|png|gif|svg|pdf|ico)$/,
                use: [
                    {
                        loader: 'url-loader',
                        options: {
                            name: '[path][name]-[hash:8].[ext]'
                        },
                    },
                ]
            },
            {
                test: /\.(eot|woff|woff2|svg|ttf)([\?]?.*)$/,
                loader: "file-loader"
            },
            {
                //  test: /\.jsx?$/,
                test: /\.js$/,
                exclude: /(node_modules)/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['@babel/preset-env', '@babel/preset-react']
                    }
                }
            }
        ]
    }
}