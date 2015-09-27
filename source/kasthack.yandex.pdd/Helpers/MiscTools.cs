/*
        stuff from https://github.com/kasthack/VKSharp/blob/master/Sources/VKSharp/Helpers/
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace kasthack.yandex.pdd.Helpers {
    internal static class MiscTools {
        /// <summary>
        /// Converts CamelCase targetInnerType snake_case
        /// </summary>
        /// <param name="name">Name for converting</param>
        /// <returns>Converted string</returns>
        public static string ToSnake( this string name ) {
            var t = new StringBuilder();
            t.Append( Char.ToLower( name[ 0 ] ) );
            for ( var index = 1; index < name.Length; index++ ) {
                var c = name[ index ];
                //add '_' before numbers and captials 
                if ( Char.IsUpper( c )
                     || ( Char.IsNumber( c ) && !Char.IsNumber( name[ index - 1 ] ) ) ) {
                    t.Append( '_' );
                    t.Append( Char.ToLower( c ) );
                }
                else t.Append( c );
            }
            return t.ToString();
        }

        public static string ToMeth( this string name, bool p = false ) {
            var t = new StringBuilder();
            t.Append( p ? Char.ToLower( name[ 0 ] ) : Char.ToUpper( name[ 0 ] ) );
            for ( var index = 1; index < name.Length; index++ ) {
                var c = name[ index ];
                //add '_' before numbers and capitals 
                if ( c == '.'
                     || c == '_' ) t.Append( Char.ToUpper( name[ ++index ] ) );
                else t.Append( c );
            }
            return t.ToString();
        }

        public static string ToNCString<T>( this T? input ) where T : struct, IFormattable => input.HasValue ? input.Value.ToNCString() : "";

        public static string ToNCString<T>( this T value ) where T : IFormattable => ( (IFormattable) value ).ToString( null, BuiltInData.Instance.NC );

        public static string ToNClString<T>( this T value ) where T : IFormattable => ( (IFormattable) value ).ToString( null, BuiltInData.Instance.NC ).ToLower( BuiltInData.Instance.NC );

        public static string ToNCStringA<T>( this IEnumerable<T> value ) where T : IFormattable => String.Join( ",", value.Select( a => ToNCString<T>( a ) ) );
        public static string ToYesNo( this bool value ) => value ? "yes" : "no";
        public static string ToYesNo(this bool? value) => value?.ToYesNo();
        public static JsonReader ToJSONReader(this string source) => new JsonTextReader(new StringReader( source ));
    }//
}