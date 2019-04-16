
build:

```
PATH=.\node_modules\.bin;C:\VS2017\Web\External;%PATH%;C:\VS2017\Common7\IDE\CommonExtensions\Microsoft\TeamFoundation\Team Explorer\Git\cmd;C:\VS2017\Common7\IDE\CommonExtensions\Microsoft\TeamFoundation\Team Explorer\Git\mingw32\bin
"C:\VS2017\Web\External\npm.CMD" install
npm WARN install Couldn't install optional dependency: Unsupported
WebReactRedux20@0.0.0 E:\zylSelf\Code\cs\vscsprojects\vs15_2017\Web\WebReactRedux20\WebReactRedux20
├── @types/history@4.6.0 
├── @types/react@15.0.35 
├── @types/react-dom@15.5.1 
├── @types/react-hot-loader@3.0.3 
├── @types/react-redux@4.4.45 
├── @types/react-router@4.0.12 
├── @types/react-router-dom@4.0.5 
├── @types/react-router-redux@5.0.3 
├─┬ @types/webpack@2.2.15 
│ ├── @types/node@8.0.7 
│ ├── @types/tapable@0.2.3 
│ └─┬ @types/uglify-js@2.6.29 
│   └── @types/source-map@0.5.0 
├── @types/webpack-env@1.13.0 
├── aspnet-prerendering@3.0.1 
├─┬ aspnet-webpack@2.0.1 
│ ├─┬ connect@3.6.2 
│ │ ├─┬ debug@2.6.7 
│ │ │ └── ms@2.0.0 
│ │ ├─┬ finalhandler@1.0.3 
│ │ │ ├── encodeurl@1.0.1 
│ │ │ ├── escape-html@1.0.3 
│ │ │ ├─┬ on-finished@2.3.0 
│ │ │ │ └── ee-first@1.1.1 
│ │ │ ├── statuses@1.3.1 
│ │ │ └── unpipe@1.0.0 
│ │ ├── parseurl@1.3.1 
│ │ └── utils-merge@1.0.0 
│ ├── es6-promise@3.3.1 
│ ├─┬ memory-fs@0.3.0 
│ │ ├─┬ errno@0.1.4 
│ │ │ └── prr@0.0.0 
│ │ └─┬ readable-stream@2.3.3 
│ │   ├── core-util-is@1.0.2 
│ │   ├── inherits@2.0.3 
│ │   ├── isarray@1.0.0 
│ │   ├── process-nextick-args@1.0.7 
│ │   ├── safe-buffer@5.1.1 
│ │   ├── string_decoder@1.0.3 
│ │   └── util-deprecate@1.0.2 
│ ├── require-from-string@1.2.1 
│ ├─┬ webpack-dev-middleware@1.11.0 
│ │ ├── memory-fs@0.4.1 
│ │ ├── path-is-absolute@1.0.1 
│ │ └── range-parser@1.2.0 
│ └── webpack-node-externals@1.6.0 
├── aspnet-webpack-react@3.0.0 
├─┬ awesome-typescript-loader@3.2.1 
│ ├── colors@1.1.2 
│ ├─┬ enhanced-resolve@3.3.0 
│ │ ├── graceful-fs@4.1.11 
│ │ └── memory-fs@0.4.1 
│ ├─┬ loader-utils@1.1.0 
│ │ ├── big.js@3.1.3 
│ │ └── emojis-list@2.1.0 
│ ├── lodash@4.17.4 
│ ├─┬ micromatch@3.0.3 
│ │ ├── arr-diff@4.0.0 
│ │ ├── array-unique@0.3.2 
│ │ ├─┬ braces@2.2.2 
│ │ │ ├── arr-flatten@1.1.0 
│ │ │ ├─┬ fill-range@4.0.0 
│ │ │ │ ├─┬ is-number@3.0.0 
│ │ │ │ │ └── kind-of@3.2.2 
│ │ │ │ ├── repeat-string@1.6.1 
│ │ │ │ └─┬ to-regex-range@2.1.1 
│ │ │ │   └── is-number@3.0.0 
│ │ │ ├── isobject@3.0.1 
│ │ │ ├── repeat-element@1.1.2 
│ │ │ ├─┬ snapdragon-node@2.1.1 
│ │ │ │ ├── isobject@3.0.1 
│ │ │ │ └── snapdragon-util@3.0.1 
│ │ │ └── split-string@2.1.1 
│ │ ├─┬ define-property@1.0.0 
│ │ │ └─┬ is-descriptor@1.0.0 
│ │ │   ├── is-accessor-descriptor@0.1.6 
│ │ │   ├── is-data-descriptor@0.1.4 
│ │ │   ├── kind-of@3.2.2 
│ │ │   └─┬ lazy-cache@2.0.2 
│ │ │     └── set-getter@0.1.0 
│ │ ├─┬ extend-shallow@2.0.1 
│ │ │ └── is-extendable@0.1.1 
│ │ ├─┬ extglob@1.1.0 
│ │ │ ├─┬ define-property@0.2.5 
│ │ │ │ └─┬ is-descriptor@0.1.5 
│ │ │ │   ├── kind-of@3.2.2 
│ │ │ │   └── lazy-cache@2.0.2 
│ │ │ ├─┬ expand-brackets@2.1.4 
│ │ │ │ ├── define-property@0.2.5 
│ │ │ │ └── posix-character-classes@0.1.1 
│ │ │ └─┬ to-regex@2.1.0 
│ │ │   └── regex-not@0.1.2 
│ │ ├─┬ fragment-cache@0.2.1 
│ │ │ └── map-cache@0.2.2 
│ │ ├─┬ kind-of@4.0.0 
│ │ │ └── is-buffer@1.1.5 
│ │ ├─┬ nanomatch@1.2.0 
│ │ │ ├── arr-diff@4.0.0 
│ │ │ ├── array-unique@0.3.2 
│ │ │ ├── is-extglob@2.1.1 
│ │ │ ├─┬ is-odd@1.0.0 
│ │ │ │ └── is-number@3.0.0 
│ │ │ └── kind-of@4.0.0 
│ │ ├─┬ object.pick@1.2.0 
│ │ │ └── isobject@2.1.0 
│ │ ├── regex-not@1.0.0 
│ │ ├─┬ snapdragon@0.8.1 
│ │ │ ├─┬ base@0.11.1 
│ │ │ │ ├── arr-union@3.1.0 
│ │ │ │ ├─┬ cache-base@0.8.5 
│ │ │ │ │ ├─┬ collection-visit@0.2.3 
│ │ │ │ │ │ ├── lazy-cache@2.0.2 
│ │ │ │ │ │ ├─┬ map-visit@0.1.5 
│ │ │ │ │ │ │ └── lazy-cache@2.0.2 
│ │ │ │ │ │ └── object-visit@0.3.4 
│ │ │ │ │ ├── get-value@2.0.6 
│ │ │ │ │ ├─┬ has-value@0.3.1 
│ │ │ │ │ │ └── has-values@0.1.4 
│ │ │ │ │ ├── isobject@3.0.1 
│ │ │ │ │ ├── lazy-cache@2.0.2 
│ │ │ │ │ ├─┬ set-value@0.4.3 
│ │ │ │ │ │ └─┬ is-plain-object@2.0.3 
│ │ │ │ │ │   └── isobject@3.0.1 
│ │ │ │ │ ├── to-object-path@0.3.0 
│ │ │ │ │ ├── union-value@0.2.4 
│ │ │ │ │ └─┬ unset-value@0.1.2 
│ │ │ │ │   └── isobject@3.0.1 
│ │ │ │ ├─┬ class-utils@0.3.5 
│ │ │ │ │ ├─┬ define-property@0.2.5 
│ │ │ │ │ │ └── is-descriptor@0.1.5 
│ │ │ │ │ ├── isobject@3.0.1 
│ │ │ │ │ ├── lazy-cache@2.0.2 
│ │ │ │ │ └─┬ static-extend@0.1.2 
│ │ │ │ │   ├─┬ define-property@0.2.5 
│ │ │ │ │   │ └─┬ is-descriptor@0.1.5 
│ │ │ │ │   │   └── lazy-cache@2.0.2 
│ │ │ │ │   └─┬ object-copy@0.1.0 
│ │ │ │ │     ├── copy-descriptor@0.1.1 
│ │ │ │ │     └─┬ define-property@0.2.5 
│ │ │ │ │       └─┬ is-descriptor@0.1.5 
│ │ │ │ │         └── lazy-cache@2.0.2 
│ │ │ │ ├── component-emitter@1.2.1 
│ │ │ │ ├─┬ define-property@0.2.5 
│ │ │ │ │ └── is-descriptor@0.1.5 
│ │ │ │ ├── lazy-cache@2.0.2 
│ │ │ │ ├─┬ mixin-deep@1.2.0 
│ │ │ │ │ └── for-in@1.0.2 
│ │ │ │ └── pascalcase@0.1.1 
│ │ │ ├─┬ define-property@0.2.5 
│ │ │ │ └─┬ is-descriptor@0.1.5 
│ │ │ │   └── lazy-cache@2.0.2 
│ │ │ ├─┬ source-map-resolve@0.5.0 
│ │ │ │ ├── atob@2.0.3 
│ │ │ │ ├── resolve-url@0.2.1 
│ │ │ │ ├── source-map-url@0.4.0 
│ │ │ │ └── urix@0.1.0 
│ │ │ └─┬ use@2.0.2 
│ │ │   ├─┬ define-property@0.2.5 
│ │ │   │ └── is-descriptor@0.1.5 
│ │ │   ├── isobject@3.0.1 
│ │ │   └── lazy-cache@2.0.2 
│ │ └─┬ to-regex@3.0.1 
│ │   └─┬ define-property@0.2.5 
│ │     └─┬ is-descriptor@0.1.5 
│ │       └── lazy-cache@2.0.2 
│ ├─┬ mkdirp@0.5.1 
│ │ └── minimist@0.0.8 
│ ├── object-assign@4.1.1 
│ └── source-map-support@0.4.15 
├── bootstrap@3.3.7 
├─┬ css-loader@0.28.4 
│ ├─┬ babel-code-frame@6.22.0 
│ │ ├─┬ chalk@1.1.3 
│ │ │ ├── ansi-styles@2.2.1 
│ │ │ ├── escape-string-regexp@1.0.5 
│ │ │ ├── has-ansi@2.0.0 
│ │ │ └── supports-color@2.0.0 
│ │ ├── esutils@2.0.2 
│ │ └── js-tokens@3.0.2 
│ ├─┬ css-selector-tokenizer@0.7.0 
│ │ ├── cssesc@0.1.0 
│ │ ├── fastparse@1.1.1 
│ │ └─┬ regexpu-core@1.0.0 
│ │   ├── regenerate@1.3.2 
│ │   ├── regjsgen@0.2.0 
│ │   └─┬ regjsparser@0.1.5 
│ │     └── jsesc@0.5.0 
│ ├─┬ cssnano@3.10.0 
│ │ ├─┬ autoprefixer@6.7.7 
│ │ │ ├─┬ browserslist@1.7.7 
│ │ │ │ └── electron-to-chromium@1.3.15 
│ │ │ ├── caniuse-db@1.0.30000697 
│ │ │ ├── normalize-range@0.1.2 
│ │ │ └── num2fraction@1.2.2 
│ │ ├── decamelize@1.2.0 
│ │ ├── defined@1.0.0 
│ │ ├─┬ has@1.0.1 
│ │ │ └── function-bind@1.1.0 
│ │ ├─┬ postcss-calc@5.3.1 
│ │ │ ├── postcss-message-helpers@2.0.0 
│ │ │ └─┬ reduce-css-calc@1.3.0 
│ │ │   ├── balanced-match@0.4.2 
│ │ │   ├── math-expression-evaluator@1.2.17 
│ │ │   └── reduce-function-call@1.0.2 
│ │ ├─┬ postcss-colormin@2.2.2 
│ │ │ └─┬ colormin@1.1.2 
│ │ │   ├─┬ color@0.11.4 
│ │ │   │ ├── clone@1.0.2 
│ │ │   │ ├─┬ color-convert@1.9.0 
│ │ │   │ │ └── color-name@1.1.2 
│ │ │   │ └── color-string@0.3.0 
│ │ │   └── css-color-names@0.0.4 
│ │ ├── postcss-convert-values@2.6.1 
│ │ ├── postcss-discard-comments@2.0.4 
│ │ ├── postcss-discard-duplicates@2.1.0 
│ │ ├── postcss-discard-empty@2.1.0 
│ │ ├── postcss-discard-overridden@0.1.1 
│ │ ├─┬ postcss-discard-unused@2.2.3 
│ │ │ └── uniqs@2.0.0 
│ │ ├─┬ postcss-filter-plugins@2.0.2 
│ │ │ └─┬ uniqid@4.1.1 
│ │ │   └── macaddress@0.2.8 
│ │ ├── postcss-merge-idents@2.1.7 
│ │ ├── postcss-merge-longhand@2.0.2 
│ │ ├─┬ postcss-merge-rules@2.1.2 
│ │ │ ├─┬ caniuse-api@1.6.1 
│ │ │ │ ├── lodash.memoize@4.1.2 
│ │ │ │ └── lodash.uniq@4.5.0 
│ │ │ ├─┬ postcss-selector-parser@2.2.3 
│ │ │ │ ├── flatten@1.0.2 
│ │ │ │ ├── indexes-of@1.0.1 
│ │ │ │ └── uniq@1.0.1 
│ │ │ └── vendors@1.0.1 
│ │ ├── postcss-minify-font-values@1.0.5 
│ │ ├── postcss-minify-gradients@1.0.5 
│ │ ├─┬ postcss-minify-params@1.2.2 
│ │ │ └── alphanum-sort@1.0.2 
│ │ ├── postcss-minify-selectors@2.1.1 
│ │ ├── postcss-normalize-charset@1.1.1 
│ │ ├─┬ postcss-normalize-url@3.0.8 
│ │ │ └─┬ normalize-url@1.9.1 
│ │ │   ├── prepend-http@1.0.4 
│ │ │   ├─┬ query-string@4.3.4 
│ │ │   │ └── strict-uri-encode@1.1.0 
│ │ │   └─┬ sort-keys@1.1.2 
│ │ │     └── is-plain-obj@1.1.0 
│ │ ├── postcss-ordered-values@2.2.3 
│ │ ├── postcss-reduce-idents@2.4.0 
│ │ ├── postcss-reduce-initial@1.0.1 
│ │ ├── postcss-reduce-transforms@1.0.4 
│ │ ├─┬ postcss-svgo@2.1.6 
│ │ │ ├─┬ is-svg@2.1.0 
│ │ │ │ └── html-comment-regex@1.1.1 
│ │ │ └─┬ svgo@0.7.2 
│ │ │   ├─┬ coa@1.0.3 
│ │ │   │ └── q@1.5.0 
│ │ │   ├─┬ csso@2.3.2 
│ │ │   │ └── clap@1.2.0 
│ │ │   ├─┬ js-yaml@3.7.0 
│ │ │   │ ├─┬ argparse@1.0.9 
│ │ │   │ │ └── sprintf-js@1.0.3 
│ │ │   │ └── esprima@2.7.3 
│ │ │   ├── sax@1.2.4 
│ │ │   └── whet.extend@0.9.9 
│ │ ├── postcss-unique-selectors@2.0.2 
│ │ └── postcss-zindex@2.2.0 
│ ├─┬ icss-utils@2.1.0 
│ │ └─┬ postcss@6.0.6 
│ │   ├─┬ chalk@2.0.1 
│ │   │ └── ansi-styles@3.1.0 
│ │   └─┬ supports-color@4.2.0 
│ │     └── has-flag@2.0.0 
│ ├── lodash.camelcase@4.3.0 
│ ├─┬ postcss@5.2.17 
│ │ ├── js-base64@2.1.9 
│ │ └── supports-color@3.2.3 
│ ├─┬ postcss-modules-extract-imports@1.1.0 
│ │ └─┬ postcss@6.0.6 
│ │   ├─┬ chalk@2.0.1 
│ │   │ └── ansi-styles@3.1.0 
│ │   └─┬ supports-color@4.2.0 
│ │     └── has-flag@2.0.0 
│ ├─┬ postcss-modules-local-by-default@1.2.0 
│ │ └─┬ postcss@6.0.6 
│ │   ├─┬ chalk@2.0.1 
│ │   │ └── ansi-styles@3.1.0 
│ │   └─┬ supports-color@4.2.0 
│ │     └── has-flag@2.0.0 
│ ├─┬ postcss-modules-scope@1.1.0 
│ │ └─┬ postcss@6.0.6 
│ │   ├─┬ chalk@2.0.1 
│ │   │ └── ansi-styles@3.1.0 
│ │   └─┬ supports-color@4.2.0 
│ │     └── has-flag@2.0.0 
│ ├─┬ postcss-modules-values@1.3.0 
│ │ ├── icss-replace-symbols@1.1.0 
│ │ └─┬ postcss@6.0.6 
│ │   ├─┬ chalk@2.0.1 
│ │   │ └── ansi-styles@3.1.0 
│ │   └─┬ supports-color@4.2.0 
│ │     └── has-flag@2.0.0 
│ ├── postcss-value-parser@3.3.0 
│ └── source-list-map@0.1.8 
├─┬ domain-task@3.0.3 
│ ├── domain-context@0.5.1 
│ ├── is-absolute-url@2.1.0 
│ └─┬ isomorphic-fetch@2.2.1 
│   ├─┬ node-fetch@1.7.1 
│   │ ├─┬ encoding@0.1.12 
│   │ │ └── iconv-lite@0.4.18 
│   │ └── is-stream@1.1.0 
│   └── whatwg-fetch@2.0.3 
├── event-source-polyfill@0.0.9 
├─┬ extract-text-webpack-plugin@2.1.2 
│ ├── async@2.5.0 
│ ├─┬ schema-utils@0.3.0 
│ │ └─┬ ajv@5.2.1 
│ │   ├── fast-deep-equal@1.0.0 
│ │   └── json-schema-traverse@0.3.1 
│ └─┬ webpack-sources@1.0.1 
│   └── source-list-map@2.0.0 
├── file-loader@0.11.2 
├─┬ history@4.6.3 
│ ├── invariant@2.2.2 
│ ├── loose-envify@1.3.1 
│ ├── resolve-pathname@2.1.0 
│ ├── value-equal@0.2.1 
│ └── warning@3.0.0 
├── jquery@3.2.1 
├── node-noop@1.0.0 
├─┬ react@15.6.1 
│ ├── create-react-class@15.6.0 
│ ├─┬ fbjs@0.8.12 
│ │ ├── core-js@1.2.7 
│ │ ├─┬ promise@7.3.1 
│ │ │ └── asap@2.0.5 
│ │ ├── setimmediate@1.0.5 
│ │ └── ua-parser-js@0.7.13 
│ └── prop-types@15.5.10 
├── react-dom@15.6.1 
├─┬ react-hot-loader@3.0.0-beta.7 
│ ├─┬ babel-template@6.25.0 
│ │ ├─┬ babel-runtime@6.23.0 
│ │ │ ├── core-js@2.4.1 
│ │ │ └── regenerator-runtime@0.10.5 
│ │ ├─┬ babel-traverse@6.25.0 
│ │ │ ├── babel-messages@6.23.0 
│ │ │ └── globals@9.18.0 
│ │ ├─┬ babel-types@6.25.0 
│ │ │ └── to-fast-properties@1.0.3 
│ │ └── babylon@6.17.4 
│ ├─┬ global@4.3.2 
│ │ ├─┬ min-document@2.19.0 
│ │ │ └── dom-walk@0.1.1 
│ │ └── process@0.5.2 
│ ├── react-deep-force-update@2.0.1 
│ ├── react-proxy@3.0.0-alpha.1 
│ ├─┬ redbox-react@1.4.2 
│ │ ├─┬ error-stack-parser@1.3.6 
│ │ │ └── stackframe@0.3.1 
│ │ └── sourcemapped-stacktrace@1.1.6 
│ └─┬ source-map@0.4.4 
│   └── amdefine@1.0.1 
├─┬ react-redux@5.0.5 
│ ├── hoist-non-react-statics@1.2.0 
│ └── lodash-es@4.17.4 
├─┬ react-router-dom@4.1.1 
│ └─┬ react-router@4.1.1 
│   └─┬ path-to-regexp@1.7.0 
│     └── isarray@0.0.1 
├── react-router-redux@5.0.0-alpha.6 
├─┬ redux@3.7.1 
│ └── symbol-observable@1.0.4 
├── redux-thunk@2.2.0 
├── style-loader@0.18.2 
├── typescript@2.4.1 
├─┬ url-loader@0.5.9 
│ └── mime@1.3.6 
├─┬ webpack@2.5.1 
│ ├── acorn@5.1.1 
│ ├─┬ acorn-dynamic-import@2.0.2 
│ │ └── acorn@4.0.13 
│ ├─┬ ajv@4.11.8 
│ │ ├── co@4.6.0 
│ │ └─┬ json-stable-stringify@1.0.1 
│ │   └── jsonify@0.0.0 
│ ├── ajv-keywords@1.5.1 
│ ├── interpret@1.0.3 
│ ├── json-loader@0.5.4 
│ ├── json5@0.5.1 
│ ├── loader-runner@2.3.0 
│ ├── loader-utils@0.2.17 
│ ├── memory-fs@0.4.1 
│ ├─┬ node-libs-browser@2.0.0 
│ │ ├── assert@1.4.1 
│ │ ├─┬ browserify-zlib@0.1.4 
│ │ │ └── pako@0.2.9 
│ │ ├─┬ buffer@4.9.1 
│ │ │ ├── base64-js@1.2.1 
│ │ │ └── ieee754@1.1.8 
│ │ ├─┬ console-browserify@1.1.0 
│ │ │ └── date-now@0.1.4 
│ │ ├── constants-browserify@1.0.0 
│ │ ├─┬ crypto-browserify@3.11.0 
│ │ │ ├─┬ browserify-cipher@1.0.0 
│ │ │ │ ├─┬ browserify-aes@1.0.6 
│ │ │ │ │ └── buffer-xor@1.0.3 
│ │ │ │ ├─┬ browserify-des@1.0.0 
│ │ │ │ │ └── des.js@1.0.0 
│ │ │ │ └── evp_bytestokey@1.0.0 
│ │ │ ├─┬ browserify-sign@4.0.4 
│ │ │ │ ├── bn.js@4.11.7 
│ │ │ │ ├── browserify-rsa@4.0.1 
│ │ │ │ ├─┬ elliptic@6.4.0 
│ │ │ │ │ ├── brorand@1.1.0 
│ │ │ │ │ ├── hash.js@1.1.3 
│ │ │ │ │ ├── hmac-drbg@1.0.1 
│ │ │ │ │ ├── minimalistic-assert@1.0.0 
│ │ │ │ │ └── minimalistic-crypto-utils@1.0.1 
│ │ │ │ └─┬ parse-asn1@5.1.0 
│ │ │ │   └── asn1.js@4.9.1 
│ │ │ ├── create-ecdh@4.0.0 
│ │ │ ├─┬ create-hash@1.1.3 
│ │ │ │ ├── cipher-base@1.0.3 
│ │ │ │ ├─┬ ripemd160@2.0.1 
│ │ │ │ │ └── hash-base@2.0.2 
│ │ │ │ └── sha.js@2.4.8 
│ │ │ ├── create-hmac@1.1.6 
│ │ │ ├─┬ diffie-hellman@5.0.2 
│ │ │ │ └── miller-rabin@4.0.0 
│ │ │ ├── pbkdf2@3.0.12 
│ │ │ ├── public-encrypt@4.0.0 
│ │ │ └── randombytes@2.0.5 
│ │ ├── domain-browser@1.1.7 
│ │ ├── events@1.1.1 
│ │ ├── https-browserify@0.0.1 
│ │ ├── os-browserify@0.2.1 
│ │ ├── path-browserify@0.0.0 
│ │ ├── process@0.11.10 
│ │ ├── punycode@1.4.1 
│ │ ├── querystring-es3@0.2.1 
│ │ ├── stream-browserify@2.0.1 
│ │ ├─┬ stream-http@2.7.2 
│ │ │ ├── builtin-status-codes@3.0.0 
│ │ │ ├── to-arraybuffer@1.0.1 
│ │ │ └── xtend@4.0.1 
│ │ ├── string_decoder@0.10.31 
│ │ ├── timers-browserify@2.0.2 
│ │ ├── tty-browserify@0.0.0 
│ │ ├─┬ url@0.11.0 
│ │ │ └── punycode@1.3.2 
│ │ ├─┬ util@0.10.3 
│ │ │ └── inherits@2.0.1 
│ │ └─┬ vm-browserify@0.0.4 
│ │   └── indexof@0.0.1 
│ ├── source-map@0.5.6 
│ ├─┬ supports-color@3.2.3 
│ │ └── has-flag@1.0.0 
│ ├── tapable@0.2.6 
│ ├─┬ uglify-js@2.8.29 
│ │ ├── uglify-to-browserify@1.0.2 
│ │ └─┬ yargs@3.10.0 
│ │   ├── camelcase@1.2.1 
│ │   ├─┬ cliui@2.1.0 
│ │   │ ├─┬ center-align@0.1.3 
│ │   │ │ ├─┬ align-text@0.1.4 
│ │   │ │ │ └── longest@1.0.1 
│ │   │ │ └── lazy-cache@1.0.4 
│ │   │ ├── right-align@0.1.3 
│ │   │ └── wordwrap@0.0.2 
│ │   └── window-size@0.1.0 
│ ├─┬ watchpack@1.3.1 
│ │ └─┬ chokidar@1.7.0 
│ │   ├─┬ anymatch@1.3.0 
│ │   │ ├── arrify@1.0.1 
│ │   │ └─┬ micromatch@2.3.11 
│ │   │   ├── arr-diff@2.0.0 
│ │   │   ├── array-unique@0.2.1 
│ │   │   ├─┬ braces@1.8.5 
│ │   │   │ ├─┬ expand-range@1.8.2 
│ │   │   │ │ └─┬ fill-range@2.2.3 
│ │   │   │ │   ├── is-number@2.1.0 
│ │   │   │ │   └─┬ randomatic@1.1.7 
│ │   │   │ │     ├─┬ is-number@3.0.0 
│ │   │   │ │     │ └── kind-of@3.2.2 
│ │   │   │ │     └── kind-of@4.0.0 
│ │   │   │ └── preserve@0.2.0 
│ │   │   ├─┬ expand-brackets@0.1.5 
│ │   │   │ └── is-posix-bracket@0.1.1 
│ │   │   ├── extglob@0.3.2 
│ │   │   ├── filename-regex@2.0.1 
│ │   │   ├─┬ normalize-path@2.1.1 
│ │   │   │ └── remove-trailing-separator@1.0.2 
│ │   │   ├─┬ object.omit@2.0.1 
│ │   │   │ └── for-own@0.1.5 
│ │   │   ├─┬ parse-glob@3.0.4 
│ │   │   │ ├── glob-base@0.3.0 
│ │   │   │ └── is-dotfile@1.0.3 
│ │   │   └─┬ regex-cache@0.4.3 
│ │   │     ├── is-equal-shallow@0.1.3 
│ │   │     └── is-primitive@2.0.0 
│ │   ├── async-each@1.0.1 
│ │   ├── glob-parent@2.0.0 
│ │   ├─┬ is-binary-path@1.0.1 
│ │   │ └── binary-extensions@1.8.0 
│ │   ├─┬ is-glob@2.0.1 
│ │   │ └── is-extglob@1.0.0 
│ │   └─┬ readdirp@2.1.0 
│ │     ├─┬ minimatch@3.0.4 
│ │     │ └─┬ brace-expansion@1.1.8 
│ │     │   ├── balanced-match@1.0.0 
│ │     │   └── concat-map@0.0.1 
│ │     └── set-immediate-shim@1.0.1 
│ ├─┬ webpack-sources@0.2.3 
│ │ └── source-list-map@1.1.2 
│ └─┬ yargs@6.6.0 
│   ├── camelcase@3.0.0 
│   ├─┬ cliui@3.2.0 
│   │ └── wrap-ansi@2.1.0 
│   ├── get-caller-file@1.0.2 
│   ├─┬ os-locale@1.4.0 
│   │ └─┬ lcid@1.0.0 
│   │   └── invert-kv@1.0.0 
│   ├─┬ read-pkg-up@1.0.1 
│   │ ├─┬ find-up@1.1.2 
│   │ │ ├── path-exists@2.1.0 
│   │ │ └─┬ pinkie-promise@2.0.1 
│   │ │   └── pinkie@2.0.4 
│   │ └─┬ read-pkg@1.1.0 
│   │   ├─┬ load-json-file@1.1.0 
│   │   │ ├─┬ parse-json@2.2.0 
│   │   │ │ └─┬ error-ex@1.3.1 
│   │   │ │   └── is-arrayish@0.2.1 
│   │   │ ├── pify@2.3.0 
│   │   │ └─┬ strip-bom@2.0.0 
│   │   │   └── is-utf8@0.2.1 
│   │   ├─┬ normalize-package-data@2.4.0 
│   │   │ ├── hosted-git-info@2.5.0 
│   │   │ ├─┬ is-builtin-module@1.0.0 
│   │   │ │ └── builtin-modules@1.1.1 
│   │   │ ├── semver@5.3.0 
│   │   │ └─┬ validate-npm-package-license@3.0.1 
│   │   │   ├─┬ spdx-correct@1.0.2 
│   │   │   │ └── spdx-license-ids@1.2.2 
│   │   │   └── spdx-expression-parse@1.0.4 
│   │   └── path-type@1.1.0 
│   ├── require-directory@2.1.1 
│   ├── require-main-filename@1.0.1 
│   ├── set-blocking@2.0.0 
│   ├─┬ string-width@1.0.2 
│   │ ├── code-point-at@1.1.0 
│   │ └─┬ is-fullwidth-code-point@1.0.0 
│   │   └── number-is-nan@1.0.1 
│   ├── which-module@1.0.0 
│   ├── y18n@3.2.1 
│   └─┬ yargs-parser@4.2.1 
│     └── camelcase@3.0.0 
├─┬ webpack-hot-middleware@2.18.2 
│ ├── ansi-html@0.0.7 
│ ├── html-entities@1.2.1 
│ ├── querystring@0.2.0 
│ └─┬ strip-ansi@3.0.1 
│   └── ansi-regex@2.1.1 
└── webpack-merge@4.1.0 


1>------ Build started: Project: WebReactRedux20, Configuration: Debug Any CPU ------
1>WebReactRedux20 -> E:\zylSelf\Code\cs\vscsprojects\vs15_2017\Web\WebReactRedux20\WebReactRedux20\bin\Debug\netcoreapp2.0\WebReactRedux20.dll
1>v5.4.1
1>Performing first-run Webpack build...
1>Hash: c4a0f7cbefddcdb226be35390098253a644fe6de
1>Version: webpack 2.5.1
1>Child
1>    Hash: c4a0f7cbefddcdb226be
1>    Time: 7354ms
1>                                   Asset    Size  Chunks                    Chunk Names
1>    89889688147bd7575d6327160d64e760.svg  109 kB          [emitted]
1>                               vendor.js  1.6 MB       0  [emitted]  [big]  vendor
1>                              vendor.css  315 kB       0  [emitted]  [big]  vendor
1>Child
1>    Hash: 35390098253a644fe6de
1>    Time: 7336ms
1>                                   Asset     Size  Chunks                    Chunk Names
1>    89889688147bd7575d6327160d64e760.svg   109 kB          [emitted]
1>                               vendor.js  1.84 MB       0  [emitted]  [big]  vendor

```
