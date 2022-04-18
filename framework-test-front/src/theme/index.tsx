import { extendTheme, ChakraTheme } from '@chakra-ui/react'

const customTheme: Partial<ChakraTheme> = {
  colors: {
    brand: {
      100: '#da9ef5',
      200: '#b662dd',
      300: '#8b4ca8',
      500: '#5f3473',
      600: '#492858'
    },
  },
}

export const theme = extendTheme(customTheme);