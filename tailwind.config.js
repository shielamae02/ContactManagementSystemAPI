/** @type {import('tailwindcss').Config} */

const withMT = require("@material-tailwind/react/utils/withMT");

export default withMT ({
  content: [
    "./index.html",
    "./src/**/*.{html,js,jsx,ts.tsx}"
  ],
  theme: {
    extend: {
      colors: {
        dustyBlack : "#222831",
        oceanBlue : "#112D4E",
        blue : "#034D8D",
        mistyBlue : '#3F72AF',
        paleBlue : '#EDF0F7',
        skyBlue : '#D6E6F2',
        pearlWhite : '#F9F7F7',
        purpleWhite : '#EEF2FF',
        gray : {
          900: '#202225',
          800: '#2f3136'
        },
        
      },

      
    },
  },
  plugins: [],
})

